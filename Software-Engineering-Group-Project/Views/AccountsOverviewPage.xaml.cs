using SftEngGP.Database.Data;
using SftEngGP.ViewModels;
using System.Diagnostics;

namespace SftEngGP.Views;

public partial class AccountsOverviewPage : ContentPage
{
	public AccountsOverviewPage(GpDbContext context)
	{
		this.BindingContext = new AccountsOverviewViewModel(context);
		InitializeComponent();
	}
}