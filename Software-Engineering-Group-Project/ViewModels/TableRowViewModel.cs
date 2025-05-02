using System.Collections.ObjectModel;

namespace SftEngGP.ViewModels
{
    /// <summary>
    /// Contains the cells contained in a row in the table view page
    /// </summary>
    public class TableRowViewModel
    {
        public ObservableCollection<object> RowCells { get; set; }

        public TableRowViewModel(List<object> rowCells)
        {
            RowCells = new ObservableCollection<object>(rowCells.Select(c => c));
        }
    }
}