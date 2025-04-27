using SftEngGP.ViewModels;
using SftEngGP.Database.Models;

namespace SftEngGP.Views;

public partial class AccountEditPage : ContentPage
{
	public AccountEditPage(User account)
	{
		this.BindingContext = new AccountEditViewModel(account);
		InitializeComponent();
	}
}