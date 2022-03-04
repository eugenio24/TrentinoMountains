using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TrentinoMountains.Utils;
using TrentinoMountains.ViewModels.Base;
using Xamarin.Forms;

namespace TrentinoMountains.CustomControls.ViewModels
{
    class HomePageCardViewModel : BaseViewModel
    {
        #region Properties
        public string LabelText { get; set; }
        public string ImagePath { get; set; }
        public ContentPage GotoPage { get; set; }
        #endregion

        #region Commands
        public ICommand ClickCommand => new Command(async () => { if (GotoPage != null) { await Navigation.PushAsync(GotoPage); } });
        #endregion
    }
}
