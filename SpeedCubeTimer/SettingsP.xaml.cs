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
        int currenttab = -1;
        const double defaultheight = 450;
        const double defaultwidth = 800;
        public SettingsP(MainWindow mw)
        {
            InitializeComponent();
            LocUtil.LanguageChanged += LocUtil_LanguageChanged;
            LocUtil.SwitchLanguage(this, App.Language.ToString());
            var general_button = new Button() { Content = (String)Resources.MergedDictionaries[0]["general_menu"], Style = (Style) Application.Current.FindResource("ButtonStyle") };
            general_button.Click += General_button_Click;
            this.mw = mw;
            stp1.Children.Add(general_button);
            
            ar = new List<List<int>>(stp1.Children.Count);
            ar2 = new List<List<object>>(stp1.Children.Count);
            General_button_Click(null, null);


        }
        private void LocUtil_LanguageChanged(object sender, LocUtil.LanguageChangedEventArgs e)
        {
           
            LocUtil.SwitchLanguage(this, e.infivechars);
            Reload();
            
        }
        private void Reload()
        {
            stp1.Children.Clear();
            stp2.Children.Clear();
            stp3.Children.Clear();
            
            var general_button = new Button()
            {
                Content = (String)Resources.MergedDictionaries[0]["general_menu"],
                Style = (Style)Application.Current.FindResource("ButtonStyle")
            };
            general_button.Click += General_button_Click;
            ar = new List<List<int>>(stp1.Children.Count);
            ar2 = new List<List<object>>(stp1.Children.Count);
            switch (currenttab)
            {
                case -1: General_button_Click(new object(), new RoutedEventArgs());
                    break;
                case 0: General_button_Click(new object(), new RoutedEventArgs());
                    break;
                    // ADD HERE MORE IF U ADD NEW SECTION BUTTON
            }
        }
        private void General_button_Click(object sender, RoutedEventArgs e)
        {
            stp2.Children.RemoveRange(0, stp2.Children.Count);
            stp3.Children.RemoveRange(0, stp3.Children.Count);
            // create list to SAVE all objects we create to change settings
            List<FrameworkElement> gen_elem = new List<FrameworkElement>();
            // create list to INFORM a user what he's gonna change
            List<FrameworkElement> comments = new List<FrameworkElement>();
            // I. HERE WE ADD COMMENTS FOR UI CONTROLS
            var save_file_tb = new TextBlock() { // CHANGES FILE PATH OF SAVED RESULTS
                Text = (String)Resources.MergedDictionaries[0]["save_file_tb"],
                TextAlignment = TextAlignment.Center,
                Style = (Style)Application.Current.FindResource("SimpleText")
            };
            comments.Add(save_file_tb);
            
            
            var theme_tb = new TextBlock() { // CHANGES THEME OF APP
                Style = (Style)Application.Current.FindResource("SimpleText"),
                Text = (String)Resources.MergedDictionaries[0]["theme_text"],
                TextAlignment = TextAlignment.Center
            };
            comments.Add(theme_tb);
            var lang_tb = new TextBlock()
            { // CHANGES LANGUAGE OF APP
                Text = (String)Resources.MergedDictionaries[0]["lang"],
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Style = (Style)Application.Current.FindResource("SimpleText")
            };
            comments.Add(lang_tb);
            // II. HERE WE ADD UI CONTROLS
            var tbox = new System.Windows.Controls.TextBox()
            {
                Style = (Style)Application.Current.FindResource("TextBoxStyle")
            };
            tbox.Text = App.SolvedTimesTextDocPath;
            tbox.TextChanged += Tbox_TextChanged;
            gen_elem.Add(tbox); // ADDING TO LIST
            // HERE WE CREATE GRID TO PUT BUTTONS INTO IT
            Grid grid1 = new Grid();
            grid1.ColumnDefinitions.Clear();
            grid1.ColumnDefinitions.Add(new ColumnDefinition() {
                Width = new GridLength(2, GridUnitType.Star) });
            grid1.ColumnDefinitions.Add(new ColumnDefinition() {
                Width = new GridLength(1, GridUnitType.Star) });
            grid1.ColumnDefinitions.Add(new ColumnDefinition() {
                Width = new GridLength(2, GridUnitType.Star) });
            // HERE ARE BUTTONS TO CHANGE A THEME OF APP
            var button1 = new Button() { Content = (String)Resources.MergedDictionaries[0]["black"],
                Style = (Style)Application.Current.FindResource("ButtonStyle") , Name = "Black"};
            var button2 = new Button() { Content = (String)Resources.MergedDictionaries[0]["white"],
                Style = (Style)Application.Current.FindResource("ButtonStyle") , Name = "White"};
            button1.Click += Button1_Click;
            button2.Click += Button1_Click;

            grid1.Children.Add(button1);
            grid1.Children.Add(button2);

            Grid.SetColumn(button1, 0);
            Grid.SetColumn(button2, 2);

            gen_elem.Add(grid1); // ADDING TO LIST
            // HERE IS BUTTON TO CREATE NEW LANGUAGE CHANGE WINDOW
            var lang_change_but = new Button() {
                Content = (String)Resources.MergedDictionaries[0]["lang_change"],
                Style = (Style)Application.Current.FindResource("ButtonStyle")
            };
            lang_change_but.Click += Lang_change_but_Click;
            gen_elem.Add(lang_change_but); // ADDING TO LIST
            
            foreach(var v in comments)
            {
                stp2.Children.Add(v);
            }
            foreach(var v in gen_elem)
            {
                stp3.Children.Add(v);
            }
            ar.Add(new List<int>(stp3.Children.Count));
            ar2.Add(new List<object>(stp3.Children.Count));
            for(int i = 0; i < stp3.Children.Count; i++)  // change i if new elements are added
            {
                ar2[0].Add(null);
            }
            currenttab = 0;
        }

        private void Lang_change_but_Click(object sender, RoutedEventArgs e)
        {
            var lang_page = new LanguageChange(); // creating language page to navigate to it
            var back_sett = new Button() { // BUTTON'S PURPOSE: TO GO BACK OUT OF LANGUAGE CHANGE
                
                Style = (Style)App.Current.FindResource("ButtonStyle")
            };
            back_sett.SetResourceReference(ContentControl.ContentProperty, "back");
            back_sett.Click += Back_sett_Click;
            lang_page.grid.Children.Add(back_sett); // adding to page's grid button
            Grid.SetRow(back_sett, 2);
            mw.Hide();
            mw.Height = lang_page.Height + 40;
            mw.Width = lang_page.Width + 40;
            mw.Show();
            mw.Content = lang_page;
        }

        private void Back_sett_Click(object sender, RoutedEventArgs e)
        {
            mw.Content = this;
            mw.Width = defaultwidth;
            mw.Height = defaultheight;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var g = sender as System.Windows.Controls.Button;

            for (Int32 i = 0; i < stp3.Children.Count; i++)
            {
               
                    if (ar[currenttab].Contains(i))
                    {
                    ar[currenttab].Remove(i);
                    ar2[currenttab].Remove(i);
                    }

                
            }
            ar[currenttab].Add(1);
            ar2[currenttab][1] = g;
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
                        ar[currenttab].Add(0);
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
                        case 1:
                            var theme = (Themes)Enum.Parse(typeof(Themes), (ar2[i1][i2] as Button).Name);
                            ThemeChanger.Change(theme);
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
