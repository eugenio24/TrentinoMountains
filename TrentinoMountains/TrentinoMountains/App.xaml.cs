using SQLite;
using System;
using System.IO;
using TrentinoMountains.Models;
using TrentinoMountains.Services;
using TrentinoMountains.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrentinoMountains
{
    public partial class App : Application
    {
        #region Properties
        private static TracksService _tracksService;
        public static TracksService TracksService { 
            get
            {
                if(_tracksService == null)
                {
                    _tracksService = new TracksService();
                }
                return _tracksService;
            }
        }
        #endregion

        #region Constructor
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePageView());
            //MainPage = new NavigationPage(new Testing());
        }
        #endregion

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
