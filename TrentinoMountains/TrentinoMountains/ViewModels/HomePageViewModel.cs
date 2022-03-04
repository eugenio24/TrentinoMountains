using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TrentinoMountains.CustomControls.ViewModels;
using TrentinoMountains.ViewModels.Base;
using TrentinoMountains.Views;
using Xamarin.Forms;

namespace TrentinoMountains.ViewModels
{
    class HomePageViewModel : BaseViewModel
    {
        #region Properties
        public HomePageCardViewModel Card_SentieriSAT { get; set; }

        public HomePageCardViewModel Card_CustomTracks { get; set; }
        #endregion

        #region Constructor
        public HomePageViewModel(INavigation navigation) : base(navigation)
        {
            Card_SentieriSAT = new HomePageCardViewModel
            {
                LabelText = "Sentieri SAT",
                ImagePath = "TrentinoMountains.Resources.Images.HomePage.sentieri-sat.jpg",
                Navigation = navigation,
                GotoPage = new SentieriSATView()
            };

            Card_CustomTracks = new HomePageCardViewModel
            {
                LabelText = "I miei Itinerari",
                ImagePath = "TrentinoMountains.Resources.Images.HomePage.custom-tracks.jpg",
                Navigation = navigation,
                GotoPage = new CustomTracksView()
            };
        }
        #endregion

        #region Commands
        public ICommand UserProfile_Click => new Command(async () => { await Navigation.PushAsync(new UserProfileView()); });
        #endregion
    }
}
