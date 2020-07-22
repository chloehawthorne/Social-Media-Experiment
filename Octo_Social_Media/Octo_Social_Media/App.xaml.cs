using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Octo_Social_Media.Services;
using Octo_Social_Media.Views;

namespace Octo_Social_Media
{
    public partial class App : Application
    {
        //For messages
        public static string User = "User";

        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<MockDataStore>();

            MainPage = new NavigationPage(new LandingPage());
            
    }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
