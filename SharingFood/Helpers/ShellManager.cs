using SharingFood.Services;

namespace SharingFood.Helpers
{
    public interface IShellManager
    {
        void SetLoadingData(bool isLoadingData);
    }

    public class ShellManager : IShellManager
    {
        private readonly IMessengerService _messengerService;

        public ShellManager(IMessengerService messengerService)
        {
            _messengerService = messengerService;
        }

        public void SetLoadingData(bool isLoadingData)
        {
            _messengerService.Send(new LoadingDataMessage(isLoadingData));
        }
    }

    public class LoadingDataMessage
    {
        public LoadingDataMessage(bool isLoadingData)
        {
            IsLoadingData = isLoadingData;
        }

        public bool IsLoadingData { get; }
    }

    public class PostMessage
    {
        public PostMessage(string postImageBase64)
        {
            PostImageBase64 = postImageBase64;
        }

        public string PostImageBase64 { get; }
    }

    public class CityMessage
    {
        public CityMessage(string city)
        {
            City = city;
        }

        public string City { get; }
    }
}
