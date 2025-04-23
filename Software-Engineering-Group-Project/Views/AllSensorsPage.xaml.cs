using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class AllSensorsPage : ContentPage
{
    public AllSensorsPage(AllSensorsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}