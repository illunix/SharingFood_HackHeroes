using SharingFood.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using SharingFood.Helpers;
using Xamarin.Forms;

namespace SharingFood.Views.Post
{
    public class PostInfoViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly IMessengerService _messengerService;
        private readonly IDialogService _dialogService;

        private bool _isUser;
        private bool _isMod;

        private string _phoneNumber;
        private string _description;

        public PostInfoViewModel(IEntityService entityService, IMessengerService messengerService, IDialogService dialogService)
        {
            _entityService = entityService;
            _messengerService = messengerService;
            _dialogService = dialogService;

            messengerService.Register<PostMessage>(this, NotifyMe);
        }

        public bool IsUser
        {
            get => _isUser;
            set => Set(ref _isUser, value);
        }

        public bool IsMod
        {
            get => _isMod;
            set => Set(ref _isMod, value);
        }

        public string Post { get; set; }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public void NotifyMe(PostMessage obj)
        {
            Post = obj.Post;
        }

        public ICommand ReportCommand => new Command<object>(async obj =>
        {
        });

        public ICommand DeleteCommand => new Command<object>(async obj =>
        {
            
        });

        public async Task InitializeAsync()
        {

            PhoneNumber = _entityService.GetUserPhoneNumber(_entityService.GetUserEmail());

            Description = _entityService.GetPostDescription(Post);

            if (_entityService.UserIsMod(_entityService.GetUserEmail()))
                IsMod = true;
            else
                IsUser = true;
        }
    }
}
