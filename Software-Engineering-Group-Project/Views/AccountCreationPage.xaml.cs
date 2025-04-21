using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class AccountCreationPage : ContentPage
{
	public AccountCreationPage()
	{
		this.BindingContext = new AccountCreationViewModel();
		InitializeComponent();
	}
}