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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TimerCode.Code;

namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for SettingsP.xaml
    /// </summary>
    public partial class SettingsP : Page
    {
        MainWindow mw;
        List<List<int>> ar;
        List<List<object>> ar2;
        int currenttab;
        public SettingsP(MainWindow mw)
        {
            InitializeComponent();
            
            var general_button = new Button() { Content = (String)Resources.MergedDictionaries[0]["general_menu"] };
            general_button.Click += General_button_Click;
            this.mw = mw;
            stp1.Children.Add(general_button);
            ar = new List<List<int>>(stp1.Children.Count);
            ar2 = new List<List<object>>(stp1.Children.Count);
            General_button_Click(null, null);

            
        }

        private void General_button_Click(object sender, RoutedEventArgs e)
        {
            stp2.Children.RemoveRange(0, stp2.Children.Count);
            stp3.Children.RemoveRange(0, stp3.Children.Count);
            var tb = new TextBlock() { Text = (String)Resources.MergedDictionaries[0]["save_file_tb"], TextAlignment = TextAlignment.Center };
            stp2.Children.Add(tb);
            var tbox = new System.Windows.Controls.TextBox();
            tbox.Text = App.SolvedTimesTextDocPath;
            tbox.TextChanged += Tbox_TextChanged;
            stp3.Children.Add(tbox);
            
            ar.Add(new List<int>(stp3.Children.Count));
            ar2.Add(new List<object>(stp3.Children.Count));
            currenttab = 0;
        }

        private void Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var g = sender as System.Windows.Controls.TextBox;

            for (Int32 i = 0; i < stp3.Children.Count; i++)
            {
                if (stp3.Children[i] == g)
                {
                    if (!ar[currenttab].Contains(i))
                    {
                        ar[currenttab].Add(i);
                        ar2[currenttab].Add(g.Text);
                    }
                    
                }
            }
            String str = "";
            foreach(var v in ar)
            {
                foreach(var h in v)
                {
                    str += Environment.NewLine + $"{h}";
                }
            }
            MessageBox.Show(str);
            MessageBox.Show(g.Text);
        }

        private void back_b_Click(object sender, RoutedEventArgs e)
        {
            mw.Content = new MainWindowsPage(mw);
        }

        private void save_b_Click(object sender, RoutedEventArgs e)
        {
            Int32 i = 0;
            foreach(var v in ar)
            {
                foreach (var v1 in v)
                {
                    save(i, v1);
                }
                i++;
            }
        }
        private void save(int i1, int i2) // i1 is tab, i2 is an element number
        {
            switch (i1)
            {
                case 0:
                    switch (i2)
                    {
                        case 0: App.SolvedTimesTextDocPath = (String)ar2[i1][i2];
                            break;
                    }
                    break;
                case 1:
                    switch (i2)
                    {

                    }
                    break;
                case 2:
                    switch (i2)
                    {

                    }
                    break;
                case 3:
                    switch (i2)
                    {

                    }
                    break;
                case 4:
                    switch (i2)
                    {

                    }
                    break;
                    // it's gonna continue in the future
            }
        }
    }
}
