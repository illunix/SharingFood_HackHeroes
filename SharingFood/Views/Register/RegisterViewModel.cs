using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using SharingFood.Services;
using System.Threading.Tasks;
using SharingFood.Helpers;

namespace SharingFood.Views.Register
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IShellManager _shellManager;
        private readonly IMessengerService _messengerService;

        private bool _isLoadingData;

        private string _email;
        private string _password;
        private string _phoneNumber;

        public RegisterViewModel(IEntityService entityService, INavigationService navigationService, IDialogService dialogService, ICryptographyService cryptographyService,
            IShellManager shellManager, IMessengerService messengerService)
        {
            _entityService = entityService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _cryptographyService = cryptographyService;
            _shellManager = shellManager;
            _messengerService = messengerService;

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

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }

        public ICommand RegisterCommand => new Command(async () =>
        {
            _shellManager.SetLoadingData(true);

            if (IsValidEmail(Email) == false || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(PhoneNumber))
            {
                _shellManager.SetLoadingData(false);
                await _dialogService.ShowError("Sprawdź wprowadzone informacje i spróbuj ponownie.");
            }
            else if (_entityService.EmailExists(Email) == true)
            {
                _shellManager.SetLoadingData(false);
                await _dialogService.ShowError("Wprowadzony email już istnieje");
            }
            else if (PhoneNumber.Length < 9)
            {
                _shellManager.SetLoadingData(false);
                await _dialogService.ShowError("Nie prawidłowy numer telefonu");
            }
            else
            {
                await Task.Run(() => _entityService.Register(Email, _cryptographyService.ToSHA1(Password), PhoneNumber));
                await Task.Run(() => _entityService.SetUserEntry(Email));
                await Task.Run(() => _entityService.SetIsLoggedIn(true));
                await _navigationService.NaviagteToMain();
                await _navigationService.NaviagteToMain();
            }

            _shellManager.SetLoadingData(false);
        });

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
