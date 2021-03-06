﻿using System;
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
using SpeedCubeTimer.Model;
using System.ComponentModel;

namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    /// This is used to 
    public partial class AuthorizationPage : Page, INotifyPropertyChanged
    {
        Window window;
        public AuthorizationPage(Window window)
        {
            InitializeComponent();
            this.window = window;
            DataContext = this;
            LocUtil.SwitchLanguage(this, App.Language.ToString());
            LocUtil.LanguageChanged += LocUtil_LanguageChanged;
        }
        Char[] prohibited = new char[] { '/', '\\', '@', '$', '%', '&' };
        
        public event PropertyChangedEventHandler PropertyChanged;
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
        private void NotifyPropertyChanged(string nameofproperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameofproperty));
        }
        private void Save_b_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            // TODO: Implement method: create a TimerCode.Code.user,
            // NAVIGATE TO MAINWINDOWPAGE
           
            //var returned = await DBControl.GetUserAsync(login_tb.Text, password_tb.Password);
            //bool exist = returned.Item2;
            //if (exist)
            //{
            //    User user = null;
            //    user = returned.Item1;
            //    App.CurrentUser = user;
            //    App.UserPassword = user.Password.SecureStringToPassword();
            //    window.Hide();
            //    App.Serialize();
            //    MainWindow mw = new MainWindow(); // check it out
            //    mw.ShowDialog();
            //    window.Close();
            //}
            //else
            //{
            //    Message = "You have a mistake in login or password. Please check it and try again.";
            //    return;
            //}
           
        }

        private void Login_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (login_tb.Text == "")
            {
                save_b.IsEnabled = false;
                return;
            }
            foreach(var chr in prohibited)
            {
                if (login_tb.Text.Contains(chr) || password_tb.Password.Contains(chr))
                {
                    Message = "Your password or username contains one of the following characters \"/ \\ /@,%,$,%,&,/;,\" ...\"";
                    save_b.IsEnabled = false;
                    return;
                }
                   
                
            }
            Message = "";
            if (password_tb.Password != "")
            {
                save_b.IsEnabled = true;
                return;
            }
        }

        private void Password_tb_TextChanged(object sender, RoutedEventArgs e)
        {
            if (password_tb.Password == "")
            {
                save_b.IsEnabled = false;
                return;
            }
            foreach (var chr in prohibited)
            {
                
                if (password_tb.Password.Contains(chr) || login_tb.Text.Contains(chr))
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            window.Content = new CreateUserPage(window, this);
        }
        private void LocUtil_LanguageChanged(object sender, LocUtil.LanguageChangedEventArgs e)
        {
            LocUtil.SwitchLanguage(this, e.infivechars);
        }
    }
}
