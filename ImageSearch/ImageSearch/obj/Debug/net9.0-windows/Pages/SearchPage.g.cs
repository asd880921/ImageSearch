﻿#pragma checksum "..\..\..\..\Pages\SearchPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BB4F6D3AF5553A26B5E79400E962935A6EEB9DBE"
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
    /// SearchPage
    /// </summary>
    public partial class SearchPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\Pages\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Team_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.ToggleSwitch CheckRect;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.ToggleSwitch ExpandSearch;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Pages\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Pages\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button PublishButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Pages\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ContentInput;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button StartSearchButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ImageSearch;component/pages/searchpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SearchPage.xaml"
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
            this.Team_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.CheckRect = ((Wpf.Ui.Controls.ToggleSwitch)(target));
            return;
            case 3:
            this.ExpandSearch = ((Wpf.Ui.Controls.ToggleSwitch)(target));
            return;
            case 4:
            this.SearchButton = ((Wpf.Ui.Controls.Button)(target));
            
            #line 51 "..\..\..\..\Pages\SearchPage.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PublishButton = ((Wpf.Ui.Controls.Button)(target));
            
            #line 56 "..\..\..\..\Pages\SearchPage.xaml"
            this.PublishButton.Click += new System.Windows.RoutedEventHandler(this.PublishButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ContentInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.StartSearchButton = ((Wpf.Ui.Controls.Button)(target));
            
            #line 64 "..\..\..\..\Pages\SearchPage.xaml"
            this.StartSearchButton.Click += new System.Windows.RoutedEventHandler(this.StartSearchButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

