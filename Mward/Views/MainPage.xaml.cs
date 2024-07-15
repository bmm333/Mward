using Microsoft.Maui.Controls;

namespace Mward.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnViewWardrobeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WardrobePage());
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void OnAnalyticsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AnalyticsPage());
        }

        private async void OnStylistClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StylistPage());
        }
    }
}
