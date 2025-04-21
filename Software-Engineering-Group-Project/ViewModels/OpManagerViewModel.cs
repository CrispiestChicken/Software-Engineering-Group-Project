using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using SftEngGP.Data;

namespace SftEngGP.ViewModels;

public class OpManagerViewModel : ObservableObject
{
    private GpDbContext _context;

    public OpManagerViewModel(GpDbContext gpDbContext)
    {
        _context = gpDbContext;
        
    }
}