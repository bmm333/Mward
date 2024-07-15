using Microsoft.Maui.Controls;

namespace Mward.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Implement saving logic
            await DisplayAlert("Profile Saved", "Your profile has been updated.", "OK");
        }
    }
}
