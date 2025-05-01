using SftEngGP.Database.Models;
using System.Windows.Input;

namespace SftEngGP.ViewComponents;

public partial class MaintenanceAddAndEditInputs : ContentView
{
    public static readonly BindableProperty CreateOrUpdateProperty =
    BindableProperty.Create(nameof(CreateOrUpdate), typeof(string), typeof(MaintenanceAddAndEditInputs), String.Empty, propertyChanged: OnCreateOrUpdateChanged);

    public static readonly BindableProperty CreateOrUpdateCommandProperty =
    BindableProperty.Create(nameof(CreateOrUpdateCommand), typeof(ICommand), typeof(MaintenanceAddAndEditInputs), null, propertyChanged: OnCreateOrUpdateCommandChanged);


    public static readonly BindableProperty AllSensorsProperty =
    BindableProperty.Create(nameof(AllSensors), typeof(List<Sensor>), typeof(MaintenanceAddAndEditInputs), null, propertyChanged: OnAllSensorsChanged);

    public static readonly BindableProperty AllAccountsProperty =
    BindableProperty.Create(nameof(AllAccounts), typeof(List<User>), typeof(MaintenanceAddAndEditInputs), null, propertyChanged: OnAllAccountsChanged);

    public static readonly BindableProperty ErrorMessageProperty =
    BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(MaintenanceAddAndEditInputs), String.Empty, propertyChanged: OnErrorMessageChanged);

    public static readonly BindableProperty MaintenanceRecordProperty =
    BindableProperty.Create(nameof(MaintenanceRecord), typeof(Maintenance), typeof(MaintenanceAddAndEditInputs), null, propertyChanged: OnMaintenanceRecordChanged);



    public string CreateOrUpdate
    {
        get => (string)GetValue(CreateOrUpdateProperty);
        set => SetValue(CreateOrUpdateProperty, value);
    }

    public ICommand CreateOrUpdateCommand
    {
        get => (ICommand)GetValue(CreateOrUpdateCommandProperty);
        set => SetValue(CreateOrUpdateCommandProperty, value);
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

    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    public Maintenance MaintenanceRecord
    {
        get => (Maintenance)GetValue(MaintenanceRecordProperty);
        set => SetValue(MaintenanceRecordProperty, value);
    }



    private static void OnCreateOrUpdateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MaintenanceAddAndEditInputs)bindable;
        var newData = (string)newValue;

        control.SubmitButton.Text = newData;

    }

    private static void OnCreateOrUpdateCommandChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MaintenanceAddAndEditInputs)bindable;
        var newData = (ICommand)newValue;

        control.SubmitButton.Command = newData;

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

    private static void OnErrorMessageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MaintenanceAddAndEditInputs)bindable;
        var newData = (string)newValue;

        control.ErrorBox.Text = newData;

    }

    private static void OnMaintenanceRecordChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MaintenanceAddAndEditInputs)bindable;
        var newData = (Maintenance)newValue;

        // Have to convert from date only to date time.
        control.DateInput.Date = newData.Date.ToDateTime(new TimeOnly());
        control.MaintainerInput.SelectedItem = newData.UserEmail;
        control.SensorSelect.SelectedItem = newData.SensorId;
        control.CommentsInput.Text = newData.Comments;
    }



    public MaintenanceAddAndEditInputs()
	{
		InitializeComponent();
	}
}