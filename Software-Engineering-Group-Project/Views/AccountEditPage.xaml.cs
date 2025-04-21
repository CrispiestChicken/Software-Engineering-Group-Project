using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class AccountEditPage : ContentPage
{
	public AccountEditPage()
	{
		this.BindingContext = new AccountEditViewModel();
		InitializeComponent();
	}
}