using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;

namespace FringleTimer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string SolvedTimesTextDocPath { get; internal set; } = Environment.CurrentDirectory + "\\solved.txt";
        public static CultureInfo Language { get; internal set; } = CultureInfo.CurrentCulture;
        private static Themes theme = Themes.Black;
        public static Themes Theme { get { return theme; } set { theme = value; } }
        // implement the next property with a securestring variable
        public static String MySqlConStr { get { return "Server=sql7.freemysqlhosting.net; Database=sql7290629; Uid=sql7290629; Pwd=3Hkud9XFAW;"; } }
        //public static User CurrentUser { get; internal set; }
        //public static String UserPassword { get; set; }
        public class ThemeEventArgs : EventArgs
        {
            public Themes ThemeChanged { get; private set; }
            public Themes OldTheme { get; private set; }

            public ThemeEventArgs(Themes themechanged)
            {
                ThemeChanged = themechanged;
                OldTheme = App.Theme;
            }
        }
        public static void Serialize()
        {
            var path = Environment.CurrentDirectory + "//settings.txt";
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream s = new FileStream(path, FileMode.Create))
            {
                var mi = typeof(App).GetProperties().Where((a) => { return a.DeclaringType == typeof(App); });
                var single1 = mi.Single((pi) => pi.Name == "MySqlConStr");
                var single2 = mi.Single((pi) => pi.Name == "Theme");
                var list = mi.ToList();
                list.Remove(single1);
                list.Remove(single2);
                foreach (var v in list)
                {
                    var val = v.GetValue(v);
                    bf.Serialize(s, val);
                }
            }

        }
        //public static void Deserialize()
        //{
        //    var path = Environment.CurrentDirectory + "//settings.txt";
        //    if (File.Exists(path))
        //    {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        using (Stream s = new FileStream(path, FileMode.Open))
        //        {
        //            var mi = typeof(App).GetProperties().Where((a) => { return a.DeclaringType == typeof(App); }).ToList();
        //            s.Position = 0;
        //            mi.Remove(mi.Single((t) => t.Name == "Theme"));
        //            mi.Remove(mi.Single((t) => t.Name == "MySqlConStr"));
        //            foreach (var v in mi)
        //            {
        //                var d = bf.Deserialize(s);

        //                v.SetValue(null, d);



        //            }
        //            //if (CurrentUser != null) 
        //            //    // checking whether the user deserialized is valid in db, so everyth is correct
        //            //{

        //            //    //var dbuser = DBControl.GetUser(CurrentUser.Username, UserPassword);
        //            //    //CurrentUser = dbuser.Item2 ? dbuser.Item1 :
        //            //        //throw new OperationCanceledException("User doesn't exist or is deleted");
        //            //}

        //        }
        //    }
        //    else
        //    {
        //        (new HelloWindow()).ShowDialog();
        //    }
        //    // TODO: Implement a changing language UI on that one which is deserialized

        //}
    }
}
