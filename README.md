# How to navigate to the multiple controls loaded in GridTemplateColumn by Tab Key in WPF DataGrid (SfDataGrid)?

How to navigate to the multiple controls loaded in GridTemplateColumn by Tab Key in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid)?

# About the sample

By default, [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid) does not support navigation to controls within GridTemplateColumn. You can achieve this by overriding ShouldGridTryToHandleKeyDown method in GridCellTemplateRenderer.

```c#
public class SfDataGridBehavior : Behavior<SfDataGrid>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        this.AssociatedObject.CellRenderers.Remove("Template");
        this.AssociatedObject.CellRenderers.Add("Template", new CustomGridCellTemplateRenderer());
    }
}

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
```
## Requirements to run the demo
 Visual Studio 2015 and above versions
