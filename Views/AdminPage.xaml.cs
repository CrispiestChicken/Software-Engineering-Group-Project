using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class AdminPage : ContentPage
{
    public AdminPage()
    {
        this.BindingContext = new AdminViewModel();
        InitializeComponent();
    }
}