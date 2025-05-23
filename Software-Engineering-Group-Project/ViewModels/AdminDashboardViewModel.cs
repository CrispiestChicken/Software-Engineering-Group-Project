﻿using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;

namespace SftEngGP.ViewModels;

/// <summary>
/// ViewModel for the Admin Dashboard.
/// </summary>
public partial class AdminDashboardViewModel : ObservableObject
{
    private GpDbContext _context;
    public AdminDashboardViewModel(GpDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Command to navigate to the Accounts Overview page.
    /// </summary>
    [RelayCommand]
    private async void AccountsButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new AccountsOverviewPage(_context));

    /// <summary>
    /// Command to navigate to the Sensors Overview page.
    /// </summary>
    [RelayCommand]
    private async void SensorsButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new SensorsOverviewPage());
}