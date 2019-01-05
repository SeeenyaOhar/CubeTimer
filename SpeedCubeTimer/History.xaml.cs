using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimerCode.Code;
namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        StackPanel[] sps = new StackPanel[3];
        MainWindow mw;
        MainWindowsPage mwp;
        public History(MainWindow mw, MainWindowsPage mwp)
        {
            InitializeComponent();
            //DivideGrid(Time.History.Count);
            ImplementUI(Time.History.Count);
            this.mw = mw;
            this.mwp = mwp;
        }
        void ImplementUI(Int32 countofelements)
        {
            Int32 index = countofelements;
            var index2 = 0;
            List<Time> ar = Time.History.ToList();
            
            grid.RowDefinitions[0].Height = new GridLength(4, GridUnitType.Star);
            grid.RowDefinitions[1].Height = new GridLength(11, GridUnitType.Star);
            if (countofelements > 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star)});
                }
            }
            else
            {
                if (countofelements != 0)
                {
                    for (int i = 0; i < countofelements - 1; i++)
                    {
                        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) });
                    }
                }
                else
                {
                    TextBlock tb = new TextBlock() { FontSize = 30, Text = "None time in history was found!",
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center};
                    grid.Children.Add(tb);
                    Grid.SetRow(tb, 1);
                    Grid.SetColumnSpan(tb,2);
                    return;
                }
            }
            Grid.SetColumnSpan(history_tb, 3);
            Grid.SetRow(history_tb, 0);
            
            sps = new StackPanel[grid.ColumnDefinitions.Count];
            for (int i = 0; i < grid.ColumnDefinitions.Count - 1; i++)
            {
                sps[i] = new StackPanel();
                grid.Children.Add(sps[i]);
                Grid.SetRow(sps[i], 2);
                Grid.SetColumn(sps[i], i + 1);
                var btn = new Button() { Content = ar.Last().ToString(), FontSize = 14, Name = $"btn{index2}" };
                btn.Click += Btn_Click;
                ar.RemoveAt(ar.Count - 1);
                sps[i].Children.Add(btn);
                index2++;
            }

            while (ar.Count != 0)
            {
                int i2 = 0;
                while (i2 != 3 && ar.Count != 0)
                {
                    var btn = new Button()
                    {
                        Content = ar.Last().ToString(),
                        FontSize = 14,
                        Name = $"btn{index2}"
                    };
                    sps[i2].Children.Add(btn);
                    btn.Click += Btn_Click;
                    ar.RemoveAt(ar.Count - 1);
                    index2++;
                    i2++;
                }
            }

            Grid.SetColumnSpan(history_tb, 5);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button) sender;
            Int32 index2 = Int32.Parse(obj.Name.Split(new[] { 'n' })[1]);
            if (obj != null)
            {
                Time t = Time.History[Time.History.Count - index2 - 1];
                MessageBox.Show($"{t} -- {t.Scramble}");
            }
           
        }

        private void Back_b_Click(object sender, RoutedEventArgs e)
        {
            mw.Content = mwp;
        }
    }
}
