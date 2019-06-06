using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class LanguageChange : Page
    {
        public LanguageChange()
        {
            InitializeComponent();
            LocUtil.SwitchLanguage(this, App.Language.ToString());
            this.Title = $"{this.Resources.MergedDictionaries[0]["title"]} - SpeedCubeTimer";
            LocUtil.LanguageChanged += LocUtil_LanguageChanged;
        }
        private String cur_infivechars = null; 
        CancellationTokenSource source = null;
        public LanguageChange(CancellationTokenSource source)
        {
            InitializeComponent();
            this.Title = $"{this.Resources.MergedDictionaries[0]["title"]} - SpeedCubeTimer";
            this.source = source;
        }
        

        

        

        private void Lang_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            var v = lb.SelectedValue;
            var split = (v as TextBlock).Name.Split('1');
            var infive = split[0] + '-' + split[1];
            cur_infivechars = infive;
           
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (source != null)
            {
                source.Cancel();
                HelloWindow.ChangeInnerLanguage(cur_infivechars);
                LocUtil.SwitchLanguageWithCallOut(this, cur_infivechars);
            }
            else LocUtil.SwitchLanguageWithCallOut(this, cur_infivechars);
        }
        private void LocUtil_LanguageChanged(object sender, LocUtil.LanguageChangedEventArgs e)
        {
            LocUtil.SwitchLanguage(this, e.infivechars);
        }
    }
}
