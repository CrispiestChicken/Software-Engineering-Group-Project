using System;
using System.Collections.Generic;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class AdminDashboard : ContentPage
{
    public AdminDashboard()
    {
        this.BindingContext = new AdminDashboardViewModel();
        InitializeComponent();
    }
}