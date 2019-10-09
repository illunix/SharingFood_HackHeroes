using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Auth;
using System.Json;
using SharingFood.Services;
using Xamarin.Forms.PlatformConfiguration;

namespace SharingFood.Views.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public LoginViewModel(IDialogService dialogService)
        {
        }

        public ICommand LoginWithFacebookCommand => new Command(async () =>
        {
            App.
        });
    }
}
