﻿#pragma checksum "..\..\CreateUserPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8B54D3B120C6BA9A4BC6866170D027F0E9DBB25D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SpeedCubeTimer;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SpeedCubeTimer {
    
    
    /// <summary>
    /// CreateUserPage
    /// </summary>
    public partial class CreateUserPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\CreateUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login_tb;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\CreateUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password_tb;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\CreateUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock hints;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\CreateUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock descr;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\CreateUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_b;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SpeedCubeTimer;component/createuserpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateUserPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.login_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\CreateUserPage.xaml"
            this.login_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Login_tb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.password_tb = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 51 "..\..\CreateUserPage.xaml"
            this.password_tb.PasswordChanged += new System.Windows.RoutedEventHandler(this.Password_tb_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.hints = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.descr = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.save_b = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\CreateUserPage.xaml"
            this.save_b.Click += new System.Windows.RoutedEventHandler(this.Save_b_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
