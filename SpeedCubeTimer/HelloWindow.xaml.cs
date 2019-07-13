using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using SpeedCubeTimer.Model;
namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for HelloWindow.xaml
    /// </summary>
    public partial class HelloWindow : Window
    {
        public HelloWindow()
        {
            InitializeComponent();
            InnerPages.Add(this);
            TimerAsync();
            LocUtil.LanguageChanged += LocUtil_LanguageChanged;
        }

        private void LocUtil_LanguageChanged(object sender, LocUtil.LanguageChangedEventArgs e)
        {
            ChangeInnerLanguage(e.infivechars);
        }

        public static List<FrameworkElement> InnerPages { get; internal set; } = new List<FrameworkElement>();
        volatile int i = 0;
        CancellationTokenSource cts = new CancellationTokenSource();

        private void TimerAsync()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory + "\\loc\\HelloWindow");

            Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    while (i < files.Count())
                    {
                        var temp = files[i].Split(new char[] { '.' });
                        this.Dispatcher.Invoke(()=> ChangeInnerLanguage(temp[1]));
                        i++;
                        Thread.Sleep(3000);
                    }
                    i = 0;
                }
            }, cts.Token);
        }

        
        public static void ChangeInnerLanguage(String infive)
        {
            foreach (var p in InnerPages)
                LocUtil.SwitchLanguage(p, infive);
        }

       

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Next_b_Click(object sender, RoutedEventArgs e)
        {
            var page = new LanguageChange(cts);
            this.Content = page; // switching page to the next one
            InnerPages.Add(page);
            Button button = new Button()
            {
                Style = (Style)App.Current.FindResource("MaterialDesignRaisedButton"),
                
            };
            button.SetResourceReference(ContentControl.ContentProperty, "next");
            button.Click += Button_Click;
            page.grid.Children.Add(button);
            Grid.SetColumn(button, 2);
            Grid.SetRow(button, 3);
            this.Height = page.Height + 40;
            this.Width = page.Width + 40;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            App.Serialize();
            var timerwindow = new MainWindow();
            timerwindow.ShowDialog();
            this.Close();
            //this.Height = 450;
            //this.Width = 800;
            
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string setts_path = Environment.CurrentDirectory + "\\settings.txt";
            if (File.Exists(setts_path))
            {
                File.Delete(setts_path);
            }
        }
    }
}
