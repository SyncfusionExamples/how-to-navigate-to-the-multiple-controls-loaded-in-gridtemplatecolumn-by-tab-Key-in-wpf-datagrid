using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EditingDemo
{
    public class CustomGridCellTemplateRenderer : GridCellTemplateRenderer
    {
        private FrameworkElement PreviousCurrentCellElement = null;
        public CustomGridCellTemplateRenderer()
        {

        }

        protected override bool ShouldGridTryToHandleKeyDown(KeyEventArgs e)
        {
            if (e.Key != Key.Tab)
                return base.ShouldGridTryToHandleKeyDown(e);

            bool isShiftPressed = SelectionHelper.CheckShiftKeyPressed();
            UIElement currentFocusedElement = Keyboard.FocusedElement as UIElement;
            var currentCell = this.DataGrid.SelectionController.CurrentCellManager.CurrentCell;
            var columnElement = currentCell.ColumnElement;
            //Column with Multiple controls inside DataTemplate.
            if (currentCell.GridColumn.MappingName != "SalesID")
                return base.ShouldGridTryToHandleKeyDown(e);
            if (PreviousCurrentCellElement != columnElement && currentFocusedElement is SfDataGrid)
            {
                FocusNavigationDirection focusNavigationDirection = isShiftPressed ? FocusNavigationDirection.Last : FocusNavigationDirection.First;
                TraversalRequest tRequest = new TraversalRequest(focusNavigationDirection);
                //To navigate from other column to template column
                if (columnElement.MoveFocus(tRequest))
                {
                    e.Handled = true;
                    PreviousCurrentCellElement = columnElement;
                    return false;
                }
            }
            else
            {
                FocusNavigationDirection focusNavigationDirection = isShiftPressed ? FocusNavigationDirection.First : FocusNavigationDirection.Last;
                TraversalRequest traversalRequest = new TraversalRequest(focusNavigationDirection);
                if (columnElement.MoveFocus(traversalRequest))
                {
                    if (Keyboard.FocusedElement != currentFocusedElement)
                    {
                        Keyboard.Focus(currentFocusedElement);
                        PreviousCurrentCellElement = columnElement;
                        return false;
                    }
                    //To navigate to other columns from template column
                    else
                    {
                        Keyboard.Focus(currentFocusedElement);
                        PreviousCurrentCellElement = null;
                        return base.ShouldGridTryToHandleKeyDown(e);
                    }
                }
            }

            PreviousCurrentCellElement = columnElement;
            return base.ShouldGridTryToHandleKeyDown(e);
        }
    }
}
