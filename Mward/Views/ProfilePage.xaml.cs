using Microsoft.Maui.Controls;
using Mward.Models;
using Mward.Services;
using System;

namespace Mward.Views
{
    public partial class ProfilePage : ContentPage
    {
        private readonly MongoDBService _mongoDBService;

        public ProfilePage()
        {
            InitializeComponent();
            _mongoDBService = new MongoDBService();
            LoadUserProfile();
        }

        private async void LoadUserProfile()
        {
            var profile = await _mongoDBService.GetUserProfileAsync();
            if (profile != null)
            {
                nameEntry.Text = profile.Name;
                emailEntry.Text = profile.Email;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var profile = new UserProfile
            {
                Name = nameEntry.Text,
                Email = emailEntry.Text
            };
            await _mongoDBService.SaveUserProfileAsync(profile);
            await DisplayAlert("Profile Saved", "Your profile has been updated.", "OK");
        }
    }
}
