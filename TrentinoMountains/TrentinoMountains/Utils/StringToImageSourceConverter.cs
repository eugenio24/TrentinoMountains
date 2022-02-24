using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using TrentinoMountains.Views;
using Xamarin.Forms;

namespace TrentinoMountains.Utils
{
    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromResource(value as string, typeof(HomePageView).GetTypeInfo().Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
