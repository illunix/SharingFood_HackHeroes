using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharingFood.Services;

namespace SharingFood.Views.Post
{
    public class PostEditViewModel : ViewModelBase
    {
        private readonly IEntityService _entityService;

        private string _title;
        private string _description;
        private string _postImage;

        public PostEditViewModel(IEntityService entityService)
        {
            _entityService = entityService;
        }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public string PostImage
        {
            get => _postImage;
            set => Set(ref _postImage, value);
        }
    }
}
