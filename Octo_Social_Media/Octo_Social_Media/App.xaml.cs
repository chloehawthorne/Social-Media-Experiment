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
        static SocialMediaDatabase database;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }
        public static SocialMediaDatabase Database
        {
            get
            {
                if(database == null )
                {
                    database = new SocialMediaDatabase();
                }
                return database;
            }
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
