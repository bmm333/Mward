using Microsoft.Maui.Controls;
using Mward.Services;
using System;

namespace Mward.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly FirebaseAuthService _firebaseAuthService;

        public LoginPage()
        {
            InitializeComponent();
            _firebaseAuthService = new FirebaseAuthService();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;
            try
            {
                var authLink = await _firebaseAuthService.SignInWithEmailAndPasswordAsync(email, password);
                await DisplayAlert("Login Success", $"User: {authLink.User.Email}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login Failed", ex.Message, "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;
            try
            {
                var authLink = await _firebaseAuthService.RegisterWithEmailAndPasswordAsync(email, password);
                await DisplayAlert("Registration Success", $"User: {authLink.User.Email}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Registration Failed", ex.Message, "OK");
            }
        }
    }
}
