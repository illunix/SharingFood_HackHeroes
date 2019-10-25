using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharingFood.Views.Post
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostInfo : ContentPage
    {
        public PostInfo(PostInfoViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

            Appearing += async (sender, e) => await viewModel.InitializeAsync();
        }
    }
}