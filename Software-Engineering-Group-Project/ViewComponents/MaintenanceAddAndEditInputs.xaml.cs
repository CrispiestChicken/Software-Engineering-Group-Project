namespace SftEngGP.ViewComponents;

public partial class MaintenanceAddAndEditInputs : ContentView
{
    public static readonly BindableProperty CreateOrUpdateProperty =
    BindableProperty.Create(nameof(CreateOrUpdate), typeof(string), typeof(MaintenanceAddAndEditInputs), String.Empty, propertyChanged: OnCreateOrUpdateChanged);

    public string CreateOrUpdate
    {
        get => (string)GetValue(CreateOrUpdateProperty);
        set => SetValue(CreateOrUpdateProperty, value);
    }

    private static void OnCreateOrUpdateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MaintenanceAddAndEditInputs)bindable;
        var newData = (string)newValue;

        control.SubmitButton.Text = newData;

    }



    public MaintenanceAddAndEditInputs()
	{
		InitializeComponent();
	}
}