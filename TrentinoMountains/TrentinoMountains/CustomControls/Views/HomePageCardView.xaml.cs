using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrentinoMountains.CustomControls.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrentinoMountains.CustomControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageCardView : ContentView
    {
        public HomePageCardView()
        {
            InitializeComponent();
           // BindingContext = new HomePageCardViewModel();
        }
    }
}