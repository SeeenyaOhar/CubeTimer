

using System.Windows;
using System.Windows.Controls;
using FringleTimer.ViewModels;

namespace FringleTimer.Views
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        //public DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ResourceDictionary), typeof(ResourceDictionary));
        public WelcomePage()
        {
            
            InitializeComponent();
            this.DataContext = new WelcomeViewModel();

        }
    }
   
}
