using SharingFood.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharingFood.Views.Post
{
    public class PostInfoViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;

        private string _phoneNumber;

        public PostInfoViewModel(IEntityService entityService)
        {
            _entityService = entityService;

        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }
    }
}
