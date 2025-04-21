using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		this.BindingContext = new LoginViewModel();
		InitializeComponent();
	}
}