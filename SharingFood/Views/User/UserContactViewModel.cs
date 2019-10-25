using System.Windows.Input;
using SharingFood.Services;
using Xamarin.Forms;

namespace SharingFood.Views.User
{
    public class UserContactViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;

        private string _phoneNumber;

        public UserContactViewModel(IEntityService entityService)
        {
            _entityService = entityService;

            PhoneNumber = _entityService.GetUserPhoneNumber(_entityService.GetUserEmail());
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }

        public ICommand LoginWithFacebookCommand => new Command(async () =>
        {
            // @TODO: Dzwonienie do typa
        });
    }
}
