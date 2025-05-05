using System;
using System.Collections.Generic;
using SftEngGP.Database.Data;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class AdminDashboard : ContentPage
{
    public AdminDashboard(GpDbContext context)
    {
        this.BindingContext = new AdminDashboardViewModel(context);
        InitializeComponent();
    }
}