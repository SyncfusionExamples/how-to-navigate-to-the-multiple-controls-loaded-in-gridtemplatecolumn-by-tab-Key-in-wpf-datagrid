using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace EditingDemo
{
    public class SfDataGridBehavior : Behavior<SfDataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.CellRenderers.Remove("Template");
            this.AssociatedObject.CellRenderers.Add("Template", new CustomGridCellTemplateRenderer());
        }
    }
}
