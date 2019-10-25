using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharingFood.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class User : ContentPage
    {
        public User(UserViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}