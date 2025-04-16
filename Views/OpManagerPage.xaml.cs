using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class OpManagerPage : ContentPage
{
    public OpManagerPage(OpManagerViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
