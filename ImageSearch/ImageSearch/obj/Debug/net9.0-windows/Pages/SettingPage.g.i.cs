﻿#pragma checksum "..\..\..\..\Pages\SettingPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8E93F48F53D794F46DA8F4665A93DD15A2232847"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

using ImageSearch.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Converters;
using Wpf.Ui.Markup;


namespace ImageSearch.Pages {
    
    
    /// <summary>
    /// SettingPage
    /// </summary>
    public partial class SettingPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Pages\SettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border_Theme;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Pages\SettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Themes;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\SettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border_UpdateDB;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Pages\SettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button UpdateDBButton;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Pages\SettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border_About;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\Pages\SettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button AboutButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ImageSearch;component/pages/settingpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SettingPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Border_Theme = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.Themes = ((System.Windows.Controls.ComboBox)(target));
            
            #line 49 "..\..\..\..\Pages\SettingPage.xaml"
            this.Themes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Border_UpdateDB = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.UpdateDBButton = ((Wpf.Ui.Controls.Button)(target));
            
            #line 87 "..\..\..\..\Pages\SettingPage.xaml"
            this.UpdateDBButton.Click += new System.Windows.RoutedEventHandler(this.UpdateDBButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Border_About = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.AboutButton = ((Wpf.Ui.Controls.Button)(target));
            
            #line 122 "..\..\..\..\Pages\SettingPage.xaml"
            this.AboutButton.Click += new System.Windows.RoutedEventHandler(this.AboutButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

