﻿#pragma checksum "..\..\AddProductsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C7256E754E523664CE9D47FE5A227838485D40A1CB92AFE97A4AD388641AA847"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Comfort;
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


namespace Comfort {
    
    
    /// <summary>
    /// AddProductsWindow
    /// </summary>
    public partial class AddProductsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AddProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProductsButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AddProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButtonMainWindow;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AddProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtProducts;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AddProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtNamePartners;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtCountProducts;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AddProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtExpirationDate;
        
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
            System.Uri resourceLocater = new System.Uri("/Comfort;component/addproductswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddProductsWindow.xaml"
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
            this.AddProductsButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\AddProductsWindow.xaml"
            this.AddProductsButton.Click += new System.Windows.RoutedEventHandler(this.AddProductsButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BackButtonMainWindow = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\AddProductsWindow.xaml"
            this.BackButtonMainWindow.Click += new System.Windows.RoutedEventHandler(this.BackButtonMainWindow_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TxtProducts = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxtNamePartners = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TxtCountProducts = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TxtExpirationDate = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

