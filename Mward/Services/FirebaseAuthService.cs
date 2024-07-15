using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase;

namespace Mward.Services
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private readonly FirebaseAuth _auth;

        public FirebaseAuthService()
        {
            // Ensure Firebase is initialized before using any Firebase services.
            var app = FirebaseApp.Instance;
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApiKey("YOUR_API_KEY")
                    .SetApplicationId("YOUR_APP_ID")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
            }
            _auth = FirebaseAuth.GetAuth(app);
        }

        public async Task<FirebaseUser> SignInWithEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var result = await _auth.SignInWithEmailAndPasswordAsync(email, password);
                return result.User;
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                throw new Exception("Invalid user.", ex);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception("Invalid credentials.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to sign in.", ex);
            }
        }

        public async Task<FirebaseUser> RegisterWithEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var result = await _auth.CreateUserWithEmailAndPasswordAsync(email, password);
                return result.User;
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                throw new Exception("User already exists.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to register.", ex);
            }
        }

        public async Task SignOutAsync()
        {
            await Task.Run(() => _auth.SignOut());
        }

        public FirebaseUser GetCurrentUser()
        {
            return _auth.CurrentUser;
        }
    }
}
