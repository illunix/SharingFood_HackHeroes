using System.Threading.Tasks;

namespace SharingFood.Services
{
    public interface IDialogService
    {
        Task ShowError(string message);
        Task ShowMessage(string message);
    }

    public class DialogService : IDialogService
    {
        public async Task ShowError(string message)
        {
            await App.Current.MainPage.DisplayAlert("", message, "Spróbuj ponownie");
        }

        public async Task ShowMessage(string message)
        {
            await App.Current.MainPage.DisplayAlert("", message, "Ok");
        }
    }
}
