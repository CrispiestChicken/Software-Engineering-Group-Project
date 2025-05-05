using SftEngGP.Database.Data;
using SftEngGP.ViewModels;
using SftEngGP.Database.Models;

namespace SftEngGP.Views;

public partial class AccountEditPage : ContentPage
{
	public AccountEditPage(GpDbContext context, User account)
	{
		BindingContext = new AccountEditViewModel(context, account);
		InitializeComponent();
	}
}