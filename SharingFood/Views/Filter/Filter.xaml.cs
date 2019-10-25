using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharingFood.Views.Filter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Filter : ContentPage
    {
        public Filter(FilterViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}