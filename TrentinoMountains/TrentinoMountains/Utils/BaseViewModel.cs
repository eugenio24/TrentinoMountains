using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TrentinoMountains.Utils
{
    class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Navigation
        public INavigation Navigation { get; set; } = null;
        #endregion

        #region Constructor
        public BaseViewModel(INavigation navigation = null)
        {
            Navigation = navigation;
        }
        #endregion
    }
}
