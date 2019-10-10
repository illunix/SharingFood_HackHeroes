using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using SharingFood.Services;
using UIKit;
using Xamarin.Auth;

namespace SharingFood.iOS.Services
{
    public class FacebookLoginService : IFacebookLoginService
    {
        public async Task DisplayUI(OAuth2Authenticator auth)
        {
            UIKit.UIViewController ui = auth.GetUI();
            await (UIApplication.SharedApplication.Delegate as AppDelegate).GetWindow().RootViewController.PresentViewControllerAsync(ui, true);
        }
    }
}