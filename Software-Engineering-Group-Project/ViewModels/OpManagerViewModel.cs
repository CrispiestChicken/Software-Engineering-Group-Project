using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using SftEngGP.Database.Data;

namespace SftEngGP.ViewModels;

public class OpManagerViewModel : ObservableObject
{
    private GenericGPDbContext _context;

    public OpManagerViewModel(GenericGPDbContext gpDbContext)
    {
        _context = gpDbContext;
        
    }
}