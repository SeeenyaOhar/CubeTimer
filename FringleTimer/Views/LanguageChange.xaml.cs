using FringleTimer.ViewModels;
using System.Windows.Controls;


namespace FringleTimer.Views
{
    /// <summary>
    /// Interaction logic for LanguageChange.xaml
    /// </summary>
    public partial class LanguageChange : Page
    {
        public LanguageChange()
        {
            InitializeComponent();
            this.DataContext = new LanguageChangeViewModel();
        }
    }
}
