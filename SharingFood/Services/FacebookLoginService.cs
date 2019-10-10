using System.Threading.Tasks;
using Xamarin.Auth;

namespace SharingFood.Services
{
    public interface IFacebookLoginService
    {
        Task DisplayUI(OAuth2Authenticator auth);
    }
}
