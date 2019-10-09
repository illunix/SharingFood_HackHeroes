using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SharingFood.Framework.Resolver;
using SharingFood.Views.Login;

namespace SharingFood
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Resolver.Initialise();

            var login = Resolver.Get<Login>();

            MainPage = new NavigationPage(login);
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
