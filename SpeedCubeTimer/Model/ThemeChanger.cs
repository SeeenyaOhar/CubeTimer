using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpeedCubeTimer
{
    public static class ThemeChanger
    {
        public static void Change(Themes theme)
        {
            var app = App.Current;
            var oldtheme = app.Resources.MergedDictionaries.Single((rs) => 
            rs.Source.OriginalString.Contains(@"themes/Black.xaml") 
            || rs.Source.OriginalString.Contains(@"themes/White.xaml")); 
            // obtaining ld theme-resource
            app.Resources.MergedDictionaries.Remove(oldtheme); // removing old theme because of replacing it to the new one

            app.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(@"themes/" + theme + ".xaml", UriKind.RelativeOrAbsolute) });
            App.Theme = theme;
        }
    }

    public enum Themes
    {
        Black, White
    }
    
}
