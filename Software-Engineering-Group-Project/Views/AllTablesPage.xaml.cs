using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class AllTablesPage : ContentPage
{
    public AllTablesPage(AllTablesViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}