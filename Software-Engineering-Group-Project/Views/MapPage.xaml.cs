using Microsoft.Maui.Maps;
using SftEngGP.Models;
using SftEngGP.ViewModels;
using System.Diagnostics;

namespace SftEngGP.Views;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
        this.BindingContext = new MapViewModel();
		InitializeComponent();

    }


}