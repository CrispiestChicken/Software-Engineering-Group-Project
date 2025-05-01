using SftEngGP.Database.Models;

namespace SftEngGP.ViewComponents;

public partial class MaintenanceAddAndEditInputs : ContentView
{
    public static readonly BindableProperty CreateOrUpdateProperty =
    BindableProperty.Create(nameof(CreateOrUpdate), typeof(string), typeof(MaintenanceAddAndEditInputs), String.Empty, propertyChanged: OnCreateOrUpdateChanged);

    public static readonly BindableProperty AllSensorsProperty =
    BindableProperty.Create(nameof(AllSensors), typeof(List<Sensor>), typeof(MaintenanceAddAndEditInputs), null, propertyChanged: OnAllSensorsChanged);

    public static readonly BindableProperty AllAccountsProperty =
    BindableProperty.Create(nameof(AllAccounts), typeof(List<User>), typeof(MaintenanceAddAndEditInputs), null, propertyChanged: OnAllAccountsChanged);



    public string CreateOrUpdate
    {
        get => (string)GetValue(CreateOrUpdateProperty);
        set => SetValue(CreateOrUpdateProperty, value);
    }

    public List<Sensor> AllSensors
    {
        get => (List<Sensor>)GetValue(AllSensorsProperty);
        set => SetValue(AllSensorsProperty, value);
    }

    public List<User> AllAccounts
    {
        get => (List<User>)GetValue(AllAccountsProperty);
        set => SetValue(AllAccountsProperty, value);
    }

    private static void OnCreateOrUpdateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MaintenanceAddAndEditInputs)bindable;
        var newData = (string)newValue;

        control.SubmitButton.Text = newData;

    }

    private static void OnAllSensorsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MaintenanceAddAndEditInputs)bindable;
        var newData = (List<Sensor>)newValue;

        control.SensorSelect.ItemsSource = newData;

    }

    private static void OnAllAccountsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MaintenanceAddAndEditInputs)bindable;
        var newData = (List<User>)newValue;

        control.MaintainerInput.ItemsSource = newData;

    }



    public MaintenanceAddAndEditInputs()
	{
		InitializeComponent();
	}
}