﻿#pragma checksum "..\..\MainWindowsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FD56D4B94CC9BD18A7771FF15F28EF10B9301B11"
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


namespace MVVMSpeedCubeTimer {
    
    
    /// <summary>
    /// MainWindowsPage
    /// </summary>
    public partial class MainWindowsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textblock1;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button settings_b;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button history_b;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock scramble;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock avgs;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel sp;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sec2;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dnf;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\MainWindowsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
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
            System.Uri resourceLocater = new System.Uri("/MVVMSpeedCubeTimer;component/mainwindowspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindowsPage.xaml"
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
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.textblock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.settings_b = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\MainWindowsPage.xaml"
            this.settings_b.Click += new System.Windows.RoutedEventHandler(this.settings_b_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.history_b = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\MainWindowsPage.xaml"
            this.history_b.Click += new System.Windows.RoutedEventHandler(this.history_b_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.scramble = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.avgs = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.sp = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.sec2 = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\MainWindowsPage.xaml"
            this.sec2.Click += new System.Windows.RoutedEventHandler(this.sec2_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dnf = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\MainWindowsPage.xaml"
            this.dnf.Click += new System.Windows.RoutedEventHandler(this.dnf_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

