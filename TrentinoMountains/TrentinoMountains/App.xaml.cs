using System;
using TrentinoMountains.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrentinoMountains
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HomePageView();
        }

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
