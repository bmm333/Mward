using System.Threading.Tasks;

namespace Mward.Services
{
    public interface IFirebaseAuthService
    {
        Task<string> SignInWithEmailAndPasswordAsync(string email, string password);
    }
}
