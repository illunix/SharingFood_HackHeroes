using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Auth;
using System.Json;
using SharingFood.Services;
using System.Threading.Tasks;
using SharingFood.Framework.Resolver;
using SharingFood.Helpers;

namespace SharingFood.Views.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IShellManager _shellManager;
        private readonly IMessengerService _messengerService;
        private readonly IResolver _resolver;

        private bool _isLoadingData;

        private string _email;
        private string _password;

        private bool _isAuhtenticated;

        public LoginViewModel(IEntityService entityService, INavigationService navigationService, IDialogService dialogService,
            ICryptographyService cryptographyService, IShellManager shellManager, IMessengerService messengerService, IResolver resolver)
        {
            _entityService = entityService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _cryptographyService = cryptographyService;
            _shellManager = shellManager;
            _messengerService = messengerService;
            _resolver = resolver;

            messengerService.Register<LoadingDataMessage>(this, msg => IsLoadingData = msg.IsLoadingData);
        }

        public bool IsLoadingData
        {
            get => _isLoadingData;
            set => Set(ref _isLoadingData, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            _shellManager.SetLoadingData(true);

            var email = await Task.Run(() => _entityService.GetLoginEmail(Email));
            var password = await Task.Run(() => _entityService.GetLoginPassword(_cryptographyService.ToSHA1(Password)));

            if (email == null || password == null || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                _shellManager.SetLoadingData(false);
                await _dialogService.ShowError("Sprawdź wprowadzone informacje i spróbuj ponownie.");
            }
            else
            {
                await Task.Run(() => _entityService.SetUserEntry(Email));
                await Task.Run(() => _entityService.SetUserEmail(Email));
                await Task.Run(() => _entityService.SetIsLoggedIn(true));
                await _navigationService.NaviagteToMain();
                _shellManager.SetLoadingData(false);
            }
        });

        public ICommand LoginWithFacebookCommand => new Command(async () =>
        {
            var auth = new OAuth2Authenticator(
                clientId : "2477957792528851",
                scope: "email",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));

            _shellManager.SetLoadingData(true);

            auth.Completed += async (s, eventArgs) =>
            {
                _isAuhtenticated = eventArgs.IsAuthenticated;

                if (_isAuhtenticated)
                {
                    var request = new OAuth2Request(
                        "GET",
                        new Uri("https://graph.facebook.com/me?fields=email"),
                        null,
                        eventArgs.Account);

                    var fbResponse = await request.GetResponseAsync();

                    var fbUser = JsonValue.Parse(fbResponse.GetResponseText());

                    if (_entityService.EmailExists(fbUser["email"]) == false)
                        await Task.Run(() => _entityService.Register(fbUser["email"], null, ""));

                    await Task.Run(() => _entityService.SetUserEntry(fbUser["email"]));
                    await Task.Run(() => _entityService.SetUserEmail(Email));
                    await Task.Run(() => _entityService.SetIsLoggedIn(true));
                    _shellManager.SetLoadingData(false);
                    await _navigationService.NaviagteToMain();
                }
            };

            await DependencyService.Get<IFacebookLoginService>().DisplayUI(auth);
        });

        public ICommand RegisterCommand => new Command(async () =>
        {
            await _navigationService.NaviagteTo(_resolver.Get<Register.Register>());
        });
    }
}
