using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharingFood.Services
{
    public interface INavigationService
    {
        Task NaviagteTo(ContentPage page);
    }

    public class NavigationService : INavigationService
    {
        public async Task NaviagteTo(ContentPage page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
