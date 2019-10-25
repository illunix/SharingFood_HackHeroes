using System.Windows.Input;
using Xamarin.Forms;
using SharingFood.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace SharingFood.Views.Post
{
    public class PostCreateViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly IGeolocationService _geolocationService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IDialogService _dialogService;

        private string _title;
        private string _description;
        private ImageSource _postImagePreview;

        public PostCreateViewModel(IEntityService entityService, IGeolocationService geolocationService, ICryptographyService cryptographyService, IDialogService dialogService)
        {
            _entityService = entityService;
            _geolocationService = geolocationService;
            _cryptographyService = cryptographyService;
            _dialogService = dialogService;
        }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public ImageSource PostImagePreview
        {
            get => _postImagePreview;
            set => Set(ref _postImagePreview, value);
        }

        public MediaFile PostImage { get; set; }

        public ICommand PickImageCommand => new Command(async () =>
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.IsSupported)
            {
                await _dialogService.ShowError("Twoje urzadzenia nie wspiera tej funkcji");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Large
            };

            var selectedImage = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            var base64String = _cryptographyService.ToBase64String(selectedImage);

            PostImagePreview = _cryptographyService.FromBase64String(base64String);

            PostImage = selectedImage;
        });

        public ICommand PostCreateCommand => new Command(async () =>
        {
            if (string.IsNullOrWhiteSpace(Title))
                await _dialogService.ShowError("Tytuł postu musi być podany");
            else
                await Task.Run(async () => _entityService.PostCreate(_entityService.GetUserEntry(), Title, Description, _geolocationService.GetCity(), _cryptographyService.ToBase64String(PostImage)));
        });
    }
}
