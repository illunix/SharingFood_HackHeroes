using System.Collections.ObjectModel;
using SharingFood.Services;
using Xamarin.Forms;

namespace SharingFood.Views.Post
{
    public class PostsToAcceptViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly ICryptographyService _cryptographyService;

        private ObservableCollection<Post> _post;

        public PostsToAcceptViewModel(IEntityService entityService)
        {
            _entityService = entityService;

            _post = new ObservableCollection<Post>();

            foreach (var post in _entityService.GetPostsToAccept())
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
    }
}