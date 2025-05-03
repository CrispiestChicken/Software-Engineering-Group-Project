using SftEngGP.Views;

namespace SftEngGP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            
            Routing.RegisterRoute(nameof(SensorPage), typeof(SensorPage));
            Routing.RegisterRoute(nameof(TrendsPage), typeof(TrendsPage));
            Routing.RegisterRoute(nameof(AllSensorsPage), typeof(AllSensorsPage));
            
            InitializeComponent();
        }
    }
}
