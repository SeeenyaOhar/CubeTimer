using SpeedCubeTimer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CreateUserPage.xaml
    /// </summary>
    public partial class CreateUserPage : Page, INotifyPropertyChanged
    {
        Char[] prohibited = new char[] { '/', '\\', '@', '$', '%', '&' };
        string message = "MESSAGE HERE GOES";
        public String Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                NotifyPropertyChanged(nameof(Message));
            }
        }
        Window window;
        public CreateUserPage(Window window)
        {
            InitializeComponent();
            save_b.IsEnabled = false;
            this.window = window;
            DataContext = this;
            LocUtil.SwitchLanguageWithCallOut(this, App.Language.ToString());
            LocUtil.LanguageChanged += LocUtil_LanguageChanged;
        }
        String password;
        private void NotifyPropertyChanged(string nameofproperty)
        {
            PropertyChanged?.Invoke(new object(), new PropertyChangedEventArgs(nameofproperty));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void Save_b_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement here method for registration
            User user = new User(0, login_tb.Text, password_tb.SecurePassword, "", "");
            // id = 0, because there is autoincrement func
            if (!DBControl.NewUser(user))
            {
                Message = "User exists. Change your username.";
                return;
            }
            App.CurrentUser = user;
            App.UserPassword = user.Password.SecureStringToPassword();
            App.Serialize();
            window.Hide();
            (new MainWindow()).ShowDialog();
            window.Close();
        }
        
        private void Login_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = password_tb.SecurePassword.SecureStringToPassword();
            
            if (login_tb.Text == "")
            {
                save_b.IsEnabled = false;
                return;
            }
            foreach (var chr in prohibited)
            {
                if (login_tb.Text.Contains(chr) || password.Contains(chr))
                   
                {
                    Message = "Your password contains one of the following characters \"/ \\ /@,%,$,%,&\"";
                    save_b.IsEnabled = false;
                    return;
                }
            }
            
            if (password != "")
            {
                save_b.IsEnabled = true;
                return;
            }
        }

         

        private void Password_tb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            
            password = password_tb.SecurePassword.SecureStringToPassword();
            if (password == "")
            {
                save_b.IsEnabled = false;
                return;
            }
            foreach (var chr in prohibited)
            {
                if (password.Contains(chr) || login_tb.Text.Contains(chr))
                    Message = "Your password contains one of the following characters \"/ \\ /@,%,$,%,&\"";
                save_b.IsEnabled = false;
                return;
            }
            if (login_tb.Text != "")
            {
                save_b.IsEnabled = true;
                return;
            }
        }
        private void LocUtil_LanguageChanged(object sender, LocUtil.LanguageChangedEventArgs e)
        {
            LocUtil.SwitchLanguage(this, e.infivechars);
        }
    }
}
