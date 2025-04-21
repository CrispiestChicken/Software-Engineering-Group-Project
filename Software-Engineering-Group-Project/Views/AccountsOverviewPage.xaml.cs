using SftEngGP.ViewModels;
using System.Diagnostics;

namespace SftEngGP.Views;

public partial class AccountsOverviewPage : ContentPage
{
	public AccountsOverviewPage()
	{
		this.BindingContext = new AccountsOverviewViewModel();
		InitializeComponent();
	}
}