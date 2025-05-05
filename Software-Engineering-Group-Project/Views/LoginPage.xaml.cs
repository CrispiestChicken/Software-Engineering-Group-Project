using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}