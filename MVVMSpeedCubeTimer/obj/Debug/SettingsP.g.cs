﻿#pragma checksum "..\..\SettingsP.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9BDB2E48AF211F4D1DF7B4805540618308C9F67A"
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
    /// SettingsP
    /// </summary>
    public partial class SettingsP : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\SettingsP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock settings_tb;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\SettingsP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stp1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\SettingsP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back_b;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\SettingsP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\SettingsP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stp2;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\SettingsP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stp3;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\SettingsP.xaml"
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
            System.Uri resourceLocater = new System.Uri("/MVVMSpeedCubeTimer;component/settingsp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SettingsP.xaml"
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
            this.settings_tb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.stp1 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.back_b = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\SettingsP.xaml"
            this.back_b.Click += new System.Windows.RoutedEventHandler(this.back_b_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.stp2 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.stp3 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.save_b = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\SettingsP.xaml"
            this.save_b.Click += new System.Windows.RoutedEventHandler(this.save_b_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

