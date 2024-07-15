using Firebase.Auth;
using System.Threading.Tasks;

namespace Mward.Services
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private readonly FirebaseAuthProvider _authProvider;

        public FirebaseAuthService()
        {
            _authProvider = new FirebaseAuthProvider(new FirebaseConfig("YOUR_FIREBASE_API_KEY"));
        }

        public async Task<string> SignInWithEmailAndPasswordAsync(string email, string password)
        {
            var auth = await _authProvider.SignInWithEmailAndPasswordAsync(email, password);
            return auth.FirebaseToken;
        }
    }
}
