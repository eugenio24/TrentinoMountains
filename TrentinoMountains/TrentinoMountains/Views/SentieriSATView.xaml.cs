using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projection;
using Mapsui.UI;
using Mapsui.Utilities;
using Mapsui.Widgets.ScaleBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrentinoMountains.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrentinoMountains.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SentieriSATView : ContentPage
    {
        public SentieriSATView()
        {
            InitializeComponent();
            BindingContext = new SentieriSATViewModel(mapView, Navigation);
        }
    }
}