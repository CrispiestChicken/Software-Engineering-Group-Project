using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class IndividualAccountPage : ContentPage
{
	public IndividualAccountPage()
	{
		this.BindingContext = new IndividualAccountViewModel();
		InitializeComponent();
	}
}