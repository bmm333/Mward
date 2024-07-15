using Microsoft.Maui.Controls;
using Windows.Networking.NetworkOperators;

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
            // Navigate to the Wardrobe page
            await Navigation.PushAsync(new WardrobePage());
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            // Navigate to the Profile page
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}
