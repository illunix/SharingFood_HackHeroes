using System.Collections.ObjectModel;
using Xamarin.Forms;
using SharingFood.Services;
using System.Threading.Tasks;

namespace SharingFood.Views.User
{
    public class UserPostsViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly ICryptographyService _cryptographyService;

        private ObservableCollection<Post> _post;

        public UserPostsViewModel(IEntityService entityService, ICryptographyService cryptographyService)
        {
            _entityService = entityService;
            _cryptographyService = cryptographyService;

            _post = new ObservableCollection<Post>();

            foreach (var post in _entityService.GetUserPosts(_entityService.GetUserEntry()))
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
