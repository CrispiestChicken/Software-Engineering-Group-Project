using Microsoft.Maui.Maps;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
        this.BindingContext = new MapViewModel();
		InitializeComponent();

    }


}