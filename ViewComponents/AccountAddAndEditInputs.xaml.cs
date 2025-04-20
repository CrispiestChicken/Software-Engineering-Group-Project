namespace SftEngGP.ViewComponents;

public partial class AccountAddAndEditInputs : ContentView
{


    //Chat Gpt'd

    // All of this code is databinding for the component.

    public static readonly BindableProperty CreatingAccountProperty =
    BindableProperty.Create(nameof(CreatingAccount), typeof(bool), typeof(AccountAddAndEditInputs), true, propertyChanged: OnCreatingAccountChanged);

    public static readonly BindableProperty CreateOrEditProperty =
    BindableProperty.Create(nameof(CreateOrEdit), typeof(string), typeof(AccountAddAndEditInputs), String.Empty, propertyChanged: OnCreateOrEditChanged);


    public bool CreatingAccount
    {
        get => (bool)GetValue(CreatingAccountProperty);
        set => SetValue(CreatingAccountProperty, value);
    }

    public string CreateOrEdit
    {
        get => (string)GetValue(CreateOrEditProperty);
        set => SetValue(CreateOrEditProperty, value);
    }


    private static void OnCreatingAccountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (AccountAddAndEditInputs)bindable;
        var newData = (bool)newValue;

        control.EmailInput.IsEnabled = newData;

    }

    private static void OnCreateOrEditChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (AccountAddAndEditInputs)bindable;
        var newData = (string)newValue;

        control.SubmitButton.Text = newData;

    }



    public AccountAddAndEditInputs()
	{
		InitializeComponent();
	}
}