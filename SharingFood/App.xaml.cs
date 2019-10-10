using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SharingFood.Framework.Resolver;
using SharingFood.Views.Login;
using SharingFood.Views.Main;
using SharingFood.Services;
using System.Threading.Tasks;
using System.IO;

namespace SharingFood
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Resolver.Initialise();

            var login = Resolver.Get<Login>();

            var main = Resolver.Get<Main>();

            var isLoggedIn = EntityService.IsLoggedIn();

#if DEBUG
            MainPage = new NavigationPage(login);
#else
            if (isLoggedIn == true)
                MainPage = new NavigationPage(main);
            else
                MainPage = new NavigationPage(login);
#endif
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
