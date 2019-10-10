using Android.App;
using Xamarin.Forms;
using Xamarin.Auth;
using SharingFood.Services;
using SharingFood.Droid.Services;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(FacebookLoginService))]
namespace SharingFood.Droid.Services
{
    public class FacebookLoginService : IFacebookLoginService
    {
        public async Task DisplayUI(OAuth2Authenticator auth)
        {
            global::Android.Content.Intent ui = auth.GetUI(Android.App.Application.Context.ApplicationContext);
            ((Activity)Forms.Context).StartActivityForResult(ui, -1);
        }
    }
}