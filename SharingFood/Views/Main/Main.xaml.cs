using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharingFood.Framework.Resolver;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharingFood.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        public Main(MainViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

            Task.Run(async () => viewModel.InitializeAsync());

            var timer = new System.Threading.Timer((e) =>
            {
                Task.Run(async () => await viewModel.CheckForNewPosts());
            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }
    }
}