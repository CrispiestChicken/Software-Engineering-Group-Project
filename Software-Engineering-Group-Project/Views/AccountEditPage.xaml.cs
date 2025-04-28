using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class AccountEditPage : ContentPage
{
	public AccountEditPage(int userID)
	{
		this.BindingContext = new AccountEditViewModel();
		InitializeComponent();
	}
}