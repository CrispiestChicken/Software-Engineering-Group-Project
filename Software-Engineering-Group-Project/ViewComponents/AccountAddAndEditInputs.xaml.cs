using SftEngGP.Database.Models;
using System.Windows.Input;

namespace SftEngGP.ViewComponents;

public partial class AccountAddAndEditInputs : ContentView
{

    // All of this code is databinding for the component.

    public static readonly BindableProperty CreatingAccountProperty =
    BindableProperty.Create(nameof(CreatingAccount), typeof(bool), typeof(AccountAddAndEditInputs), true, propertyChanged: OnCreatingAccountChanged);

    public static readonly BindableProperty CreateOrUpdateProperty =
    BindableProperty.Create(nameof(CreateOrUpdate), typeof(string), typeof(AccountAddAndEditInputs), String.Empty, propertyChanged: OnCreateOrUpdateChanged);

    public static readonly BindableProperty ErrorMessageProperty =
    BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(AccountAddAndEditInputs), String.Empty, propertyChanged: OnErrorMessageChanged);

    public static readonly BindableProperty AccountProperty =
    BindableProperty.Create(nameof(Account), typeof(User), typeof(AccountAddAndEditInputs), null, propertyChanged: OnAccountChanged);

    public static readonly BindableProperty CreateOrUpdateCommandProperty =
    BindableProperty.Create(nameof(CreateOrUpdateCommand), typeof(ICommand), typeof(AccountAddAndEditInputs), null, BindingMode.TwoWay, propertyChanged: OnCreateOrUpdateCommandChanged);



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

    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    public ICommand CreateOrUpdateCommand
    {
        get => (ICommand)GetValue(CreateOrUpdateCommandProperty);
        set => SetValue(CreateOrUpdateCommandProperty, value);
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

    private static void OnErrorMessageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (AccountAddAndEditInputs)bindable;
        var newData = (string)newValue;

        control.ErrorDisplay.Text = newData;

    }

    private static void OnCreateOrUpdateCommandChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (AccountAddAndEditInputs)bindable;
        var newData = (ICommand)newValue;

        control.SubmitButton.Command = newData;
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