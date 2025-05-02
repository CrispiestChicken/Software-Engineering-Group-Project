using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata;
using SftEngGP.Database.Data;

namespace SftEngGP.ViewModels;

public class AllDbSetsViewModel
{
    private GpDbContext _context;
    public ObservableCollection<DataStorageViewModel> AllTypes { get; set; }

    public AllDbSetsViewModel(GpDbContext context)
    {
        _context = context;
        AllTypes = new ObservableCollection<DataStorageViewModel>(_context.Model.GetEntityTypes().ToList().Select(e => new DataStorageViewModel(_context, e)));
        
    }
    
    
}