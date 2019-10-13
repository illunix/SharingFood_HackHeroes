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

#if DEBUG
            MainPage = new NavigationPage(Resolver.Get<Main>());
#else
            if (EntityService.IsLoggedIn() == true)
                MainPage = new NavigationPage(Resolver.Get<Main>());
            else
                MainPage = new NavigationPage(Resolver.Get<Login>(););
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
