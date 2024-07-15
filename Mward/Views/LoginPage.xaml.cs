using Microsoft.Maui.Controls;
using Mward.Services;
using System;

namespace Mward.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly IFirebaseAuthService _authService;

        public LoginPage()
        {
            InitializeComponent();
            _authService = DependencyService.Get<IFirebaseAuthService>();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please enter both email and password", "OK");
                return;
            }

            try
            {
                var token = await _authService.SignInWithEmailAndPasswordAsync(email, password);
                await DisplayAlert("Login Success", "Token: " + token, "OK");

                // Navigate to the main page or home page of your app
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login Failed", ex.Message, "OK");
            }
        }
    }
}
