using SharingFood.Framework.Resolver;
using SharingFood.Views.Main;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharingFood.Services
{
    public interface INavigationService
    {
        Task NaviagteTo(ContentPage page);
        Task NaviagteToMain();
    }

    public class NavigationService : INavigationService
    {
        public async Task NaviagteTo(ContentPage page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task NaviagteToMain()
        {
            await App.Current.MainPage.Navigation.PushAsync(Resolver.Get<Main>());
        }
    }
}
