using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SharingFood.Framework.Resolver;
using SharingFood.Helpers;
using SharingFood.Services;
using SharingFood.Views.Main;
using Xamarin.Forms;

namespace SharingFood.Views.Filter
{
    public class FilterViewModel : ViewModelBase
    {
        private readonly IResolver _resolver;
        private readonly INavigationService _navigationService;
        private readonly IMessengerService _messengerService;

        private string _city;

        public FilterViewModel(IResolver resolver, INavigationService navigationService, IMessengerService messengerService)
        {
            _resolver = resolver;
            _navigationService = navigationService;
            _messengerService = messengerService;
        }

        public string City
        {
            get => _city;
            set => Set(ref _city, value);
        }

        public ICommand SearchCommand => new Command(async () =>
        {
            await _navigationService.NaviagteTo(_resolver.Get<Main.Main>());
            _messengerService.Send(new CityMessage(City));
        });
    }
}