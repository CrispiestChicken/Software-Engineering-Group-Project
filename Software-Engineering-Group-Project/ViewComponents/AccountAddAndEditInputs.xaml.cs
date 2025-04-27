using SftEngGP.Database.Models;

namespace SftEngGP.ViewComponents;

public partial class AccountAddAndEditInputs : ContentView
{


    // All of this code is databinding for the component.

    public static readonly BindableProperty CreatingAccountProperty =
    BindableProperty.Create(nameof(CreatingAccount), typeof(bool), typeof(AccountAddAndEditInputs), true, propertyChanged: OnCreatingAccountChanged);

    public static readonly BindableProperty CreateOrUpdateProperty =
    BindableProperty.Create(nameof(CreateOrUpdate), typeof(string), typeof(AccountAddAndEditInputs), String.Empty, propertyChanged: OnCreateOrUpdateChanged);

    public static readonly BindableProperty AccountProperty =
BindableProperty.Create(nameof(Account), typeof(User), typeof(AccountAddAndEditInputs), null, propertyChanged: OnAccountChanged);


    public bool CreatingAccount
    {
        get => (bool)GetValue(CreatingAccountProperty);
        set => SetValue(CreatingAccountProperty, value);
    }

    public string CreateOrUpdate
    {
        get => (string)GetValue(CreateOrUpdateProperty);
        set => SetValue(CreateOrUpdateProperty, value);
    }

    public User Account
    {
        get => (User)GetValue(AccountProperty);
        set => SetValue(AccountProperty, value);
    }


    private static void OnCreatingAccountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (AccountAddAndEditInputs)bindable;
        var newData = (bool)newValue;

        control.EmailInput.IsEnabled = newData;

    }

    private static void OnCreateOrUpdateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (AccountAddAndEditInputs)bindable;
        var newData = (string)newValue;

        control.SubmitButton.Text = newData;

    }

    private static void OnAccountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (AccountAddAndEditInputs)bindable;
        var newData = (User)newValue;

        control.EmailInput.Text = newData.Email;
        control.FNameInput.Text = newData.Password;
        control.SNameInput.Text = newData.LName;
        control.AddressInput.Text = newData.Address;
        control.RoleInput.SelectedIndex = newData.RoleId;

    }



    public AccountAddAndEditInputs()
	{
		InitializeComponent();
	}
}