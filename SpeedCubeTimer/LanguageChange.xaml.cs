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
using System.Windows.Shapes;

namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class LanguageChange : Window
    {
        public LanguageChange()
        {
            InitializeComponent();
            this.Title = $"{this.Resources.MergedDictionaries[0]["title"]} - SpeedCubeTimer";
        }
    }
}
