using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TimerCode.Code;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;
using System.Linq;

namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public MainWindow(User user = null)
        //{
        //    InitializeComponent();
            
        //    App.Deserialize();

        //    this.Closing += MainWindow_Closing; 
        //    this.Content = new MainWindowsPage(this, user); // it won't be a problem if user is null
        //    // there is a null check
           
        //}
        public MainWindow()
        {
            InitializeComponent();

            App.Deserialize();

            this.Closing += MainWindow_Closing;
            this.Content = new MainWindowsPage(this); // , null // it won't be a problem if user is null
                                                      // there is a null check

        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var props = typeof(App).GetProperties().Where((a) => a.DeclaringType == typeof(App));
            Boolean[] exist = new Boolean[props.Count()];
            foreach(var v in props)
            {
                if (v.GetValue(null) == null)
                {
                    return;
                }
            }
            App.Serialize();
            
        }
    }
}
