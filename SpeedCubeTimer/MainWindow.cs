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
namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            App.Deserialize();
            //new LanguageChange().Show();
            // TODO: Implement a changing language UI
            this.Closing += MainWindow_Closing; // TODO: Construct command for these events
            this.Content = new MainWindowsPage(this);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Serialize();
            
        }
    }
}
