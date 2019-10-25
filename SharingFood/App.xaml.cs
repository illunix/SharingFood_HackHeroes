using Xamarin.Forms;
using SharingFood.Framework.Resolver;
using SharingFood.Views.Post;
using SharingFood.Views.Main;
using SharingFood.Views.Login;
using SharingFood.Services;

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
                MainPage = new NavigationPage(Resolver.Get<Login>());
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
