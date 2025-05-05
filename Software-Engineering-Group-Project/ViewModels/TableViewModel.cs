using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;

namespace SftEngGP.ViewModels
{
    
    /// <summary>
    /// contains the properties of a table displayed in the table view page
    /// </summary>
    public class TableViewModel
    {
        private GenericGPDbContext _context;
        public ObservableCollection<TableRowViewModel> TableRows { get; set; }
        public ObservableCollection<String> TableColumns { get; set; }

        public TableViewModel(GenericGPDbContext context, List<Dictionary<String,object>> tableDictionary)
        {
            _context = context;
            TableColumns = new ObservableCollection<string>(tableDictionary.First().Keys.Select(k => k));
            TableRows = new ObservableCollection<TableRowViewModel>(tableDictionary.Select(r => new TableRowViewModel(r.Values.Select(v => v).ToList())));

        }
    }
}