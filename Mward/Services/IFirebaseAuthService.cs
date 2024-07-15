using System.Threading.Tasks;
using Firebase.Auth;

namespace Mward.Services
{
    public interface IFirebaseAuthService
    {
        Task<FirebaseUser> SignInWithEmailAndPasswordAsync(string email, string password);
        Task<FirebaseUser> RegisterWithEmailAndPasswordAsync(string email, string password);
        Task SignOutAsync();
        FirebaseUser GetCurrentUser();
    }
}
