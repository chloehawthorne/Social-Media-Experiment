using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Octo_Social_Media.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private async void MainPageExample(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void SettingsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void AccountPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void PersonalPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void MessagePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void ChatPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatPage());
        }
        private async void TrendingPage(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());
        }
        private async void ExplorePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void SearchPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void MainFeedPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void SignUpPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void SignInPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}