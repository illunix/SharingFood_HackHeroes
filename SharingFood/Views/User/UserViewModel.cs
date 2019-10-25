using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SharingFood.Services;
using SharingFood.Framework.Resolver;

namespace SharingFood.Views.User
{
    public class UserViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;
        private readonly INavigationService _navigationService;
        private readonly IResolver _resolver;

        public UserViewModel(IEntityService entityService, INavigationService navigationService, IResolver resolver)
        {
            _entityService = entityService;
            _navigationService = navigationService;
            _resolver = resolver;
        }

        public ICommand UserPostsCommand => new Command(async () =>
        {
            await _navigationService.NaviagteTo(_resolver.Get<UserPosts>());
        });

        public ICommand LogoutCommand => new Command(async () =>
        {
            await _navigationService.NaviagteTo(_resolver.Get<Login.Login>());
            await Task.Run(() => _entityService.SetIsLoggedIn(false));
        });
    }
}