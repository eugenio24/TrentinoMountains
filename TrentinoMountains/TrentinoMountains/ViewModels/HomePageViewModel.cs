using System;
using System.Collections.Generic;
using System.Text;
using TrentinoMountains.CustomControls.ViewModels;
using TrentinoMountains.Utils;

namespace TrentinoMountains.ViewModels
{
    class HomePageViewModel : BaseViewModel
    {
        #region Properties

        public HomePageCardViewModel Card_SentieriSAT { get; set; } = new HomePageCardViewModel
        {
            LabelText = "Sentieri SAT",
            ImagePath = "TrentinoMountains.Resources.Images.HomePage.sentieri-sat.jpg"
        };

        #endregion
    }
}
