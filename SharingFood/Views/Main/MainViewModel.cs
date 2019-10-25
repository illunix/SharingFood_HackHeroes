using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using SharingFood.Framework.Resolver;
using SharingFood.Views.Post;
using SharingFood.Helpers;
using SharingFood.Services;

namespace SharingFood.Views.Main
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IGeolocationService _geolocationService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IResolver _resolver;
        private readonly IMessengerService _messengerService;

        private bool _isLoadingData;

        private bool _isUser;
        private bool _isMod;

        private ObservableCollection<Post> _post;

        private bool _showRefreshButton;

        public MainViewModel(IEntityService entityService, ICryptographyService cryptographyService, IGeolocationService geolocationService, 
            INavigationService navigationService, IDialogService dialogService, IResolver resolver, IMessengerService messengerService)
        {
            _entityService = entityService;
            _cryptographyService = cryptographyService;
            _geolocationService = geolocationService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _resolver = resolver;
            _messengerService = messengerService;

            messengerService.Register<LoadingDataMessage>(this, msg => IsLoadingData = msg.IsLoadingData);
            messengerService.Register<CityMessage>(this, NotifyMe);

            _post = new ObservableCollection<Post>();

            PostsCount = entityService.GetPosts(_geolocationService.GetCity()).Count;
        }

        public int PostsCount;

        public bool IsLoadingData
        {
            get => _isLoadingData;
            set => Set(ref _isLoadingData, value);
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

        public ObservableCollection<Post> Post
        {
            get => _post;
            set => Set(ref _post, value);
        }

        public bool ShowRefreshButton
        {
            get => _showRefreshButton;
            set => Set(ref _showRefreshButton, value);
        }

        public async Task InitializeAsync()
        {
            foreach (var post in _entityService.GetPosts(_geolocationService.GetCity()))
            {
                _post.Add(new Post
                {
                    Title = post,
                    PostImage = _cryptographyService.FromBase64String(_entityService.GetPostImage(post)),
                    Description = _entityService.GetPostDescription(post)
                });
            }

            if (_entityService.UserIsMod(_entityService.GetUserEmail()))
                IsMod = true;
            else
                IsUser = true;

            ShowRefreshButton = false;
        }

        public async Task CheckForNewPosts()
        {
            if (PostsCount < _entityService.GetPosts(_geolocationService.GetCity()).Count)
            {
                ShowRefreshButton = true;
            }
            else
            {
                ShowRefreshButton = true;
            }
        }

        public ICommand RefreshPostsCommand => new Command(async () =>
        {
            PostsCount = _entityService.GetPosts(_geolocationService.GetCity()).Count;

            _post.Clear();

            foreach (var post in _entityService.GetPosts(_geolocationService.GetCity()))
            {
                _post.Add(new Post
                {
                    Title = post,
                    PostImage = _cryptographyService.FromBase64String(_entityService.GetPostImage(post)),
                    Description = _entityService.GetPostDescription(post)
                });
            }

            ShowRefreshButton = false;
        });

        public string PostImageBase64 { get; set; }

        public ICommand PostCommand => new Command<object>(async obj =>
        {
            if (obj is string post)
            {
                await _navigationService.NaviagteTo(_resolver.Get<PostInfo>());
                _messengerService.Send(new PostMessage(post));
            }
        });

        public ICommand FilterCommand => new Command(async () =>
        {
            await _navigationService.NaviagteTo(_resolver.Get<Filter.Filter>());
        });

        public ICommand PostCreateCommand => new Command(async () =>
        {
            await _navigationService.NaviagteTo(_resolver.Get<PostCreate>());
        });

        public ICommand UserCommand => new Command(async () =>
        {
            await _navigationService.NaviagteTo(_resolver.Get<User.User>());
        });

        public ICommand PostsToAcceptCommand => new Command(async () =>
        {
            await _navigationService.NaviagteTo(_resolver.Get<PostsToAccept>());
        });

        public void NotifyMe(CityMessage obj)
        {
            _post.Clear();

            foreach (var post in _entityService.GetPosts(obj.City))
            {
                _post.Add(new Post { Title = post });
                _post.Add(new Post { PostImage = _cryptographyService.FromBase64String(_entityService.GetPostImage(post)) });
            }
        }
    }

    public class Post
    {
        public string Title { get; set; }
        public ImageSource PostImage { get; set; }
        public string Description { get; set; }
    }
}