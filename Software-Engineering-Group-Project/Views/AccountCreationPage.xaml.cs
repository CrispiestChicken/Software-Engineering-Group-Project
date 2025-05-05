using CommunityToolkit.Mvvm.Input;
using SftEngGP.Database.Data;
using SftEngGP.ViewModels;


namespace SftEngGP.Views;

public partial class AccountCreationPage : ContentPage
{
    public AccountCreationPage(AccountCreationViewModel context)
	{
		this.BindingContext = context;
		InitializeComponent();
	}


}