using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using main.Services;
using main.Views;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace main
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
