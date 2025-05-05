using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.ViewModels;

namespace SftEngGP.Views
{
    /// <summary>
    /// Displays a list of all the sensors contained in the database, clicking on one will direct the user to a page containing detailed information regarding the selected sensor
    /// </summary>
    public partial class AllSensorsPage : ContentPage
    {
        public AllSensorsPage(AllSensorsViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}