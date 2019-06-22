using SpeedCubeTimer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        Page page;
        string message = "";
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
        public CreateUserPage(Window window, Page page)
        {
            InitializeComponent();
            save_b.IsEnabled = false;
            this.window = window;
            DataContext = this;
            this.page = page;
            LocUtil.SwitchLanguageWithCallOut(this, App.Language.ToString());
            LocUtil.LanguageChanged += LocUtil_LanguageChanged;
        }
        String password;
        private void NotifyPropertyChanged(string nameofproperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameofproperty));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private async void Save_b_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement here method for registration
            User user = new User(0, login_tb.Text, password_tb.SecurePassword, "", "");
            // id = 0, because there is autoincrement func
            save_b.IsEnabled = false;
            back.IsEnabled = false;
            Task<Boolean> task = DBControl.CheckExistanceAsync(login_tb.Text);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Task sign_in_t = Task.Run(() =>
            {
                while (!task.IsCanceled || !task.IsCompleted || !task.IsFaulted || 
                !token.IsCancellationRequested)
                {
                    Message = "Signing in."; Task.Delay(6000);
                    Message = "Signing in.."; Task.Delay(6000);
                    Message = "Signing in..."; Task.Delay(6000);
                    token.ThrowIfCancellationRequested();
                }
            }, token); // NO MISTAKE HERE
            if (await task.
                ContinueWith((res) => // continue the task with unlocking some button for the user
                {
                    save_b.IsEnabled = true;
                    back.IsEnabled = true;
                    tokenSource.Cancel();
                    return res.Result; // returning result to continue the if statement
                },TaskScheduler.FromCurrentSynchronizationContext())) // if user exists, then notify the user about it
            {
                tokenSource.Cancel();
                try { sign_in_t.Wait(); } catch (AggregateException) {
                    // NOTHING HERE, JUST TO WHITE AN EXCEPTION 
                }
                
                Message = "User exists. Change your username."; // TODO: Make the password recovery
                
                return;
            }
            DBControl.NewUser(user);
            if (!tokenSource.IsCancellationRequested) tokenSource.Cancel();

            App.CurrentUser = user;
            App.UserPassword = password_tb.Password;
            
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
                    Message = "Your password or username contains one of the following characters \"/ \\ /@,%,$,%,&,/;,\" ...\"";
                    save_b.IsEnabled = false;
                    return;
                }
            }
            Message = "";
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
                {
                    Message = "Your password or username contains one of the following characters \"/ \\ /@,%,$,%,&,/;,\" ...\"";
                    save_b.IsEnabled = false;
                    return;
                }
                    
            }
            Message = "";
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            window.Content = page;
        }
    }
}
