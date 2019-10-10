using System.Windows.Input;
using Xamarin.Forms;
using SharingFood.Services;
using System.Threading.Tasks;

namespace SharingFood.Views.Register
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly ICryptographyService _cryptographyService;

        private string _email;
        private string _password;

        public RegisterViewModel(IEntityService entityService, INavigationService navigationService, IDialogService dialogService, ICryptographyService cryptographyService)
        {
            _entityService = entityService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _cryptographyService = cryptographyService;
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

        public ICommand RegisterCommand => new Command(async () =>
        {
            bool emailExists = await Task.Run(() => _entityService.CheckIfEmailExists(Email));

            if (IsValidEmail(Email) == false || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
                await _dialogService.ShowError("Sprawdź wprowadzone informacje i spróbuj ponownie.");
            else if (_entityService.CheckIfEmailExists(Email) == true)
                await _dialogService.ShowError("Wprowadzony email już istnieje");
            else
            {
                await Task.Run(() => _entityService.Register(Email, _cryptographyService.Encode(Password)));
                await Task.Run(() => _entityService.SetIsLoggedIn());
                await _navigationService.NaviagteTo(new Main.Main());
            }
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
