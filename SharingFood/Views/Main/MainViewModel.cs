using SharingFood.Services;
using SharingFood.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace SharingFood.Views.Main
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IGeolocationService _geolocationService;
        private readonly IDialogService _dialogService;

        public ObservableCollection<Post> _post;

        public ObservableCollection<Post> Post
        {
            get => _post;
            set => Set(ref _post, value);
        }

        public MainViewModel(IEntityService entityService, ICryptographyService cryptographyService, IGeolocationService geolocationService, IDialogService dialogService)
        {
            _entityService = entityService;
            _cryptographyService = cryptographyService;
            _geolocationService = geolocationService;
            _dialogService = dialogService;

            _post = new ObservableCollection<Post>();

            foreach (var post in _entityService.GetPosts())
            {
                _post.Add(new Post { Title = post });
                _post.Add(new Post { PostImage = _entityService.GetPostImage(post) });
            }
        }
    }

    public class Post
    {
        public string Title { get; set; }
        public ImageSource PostImage { get; set; }
    }
}
