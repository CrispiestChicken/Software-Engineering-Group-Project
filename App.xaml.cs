using Microsoft.Maui.ApplicationModel;

namespace SftEngGP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
