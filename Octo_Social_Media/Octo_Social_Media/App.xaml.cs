using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Octo_Social_Media.Services;
using Octo_Social_Media.Views;
using Octo_Social_Media.Data;

namespace Octo_Social_Media
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            Akavache.Registrations.Start("Octo");

            MainPage = new MainPage();
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
