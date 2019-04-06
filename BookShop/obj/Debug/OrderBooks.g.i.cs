﻿#pragma checksum "..\..\OrderBooks.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "928063CDA635826234CE84A0B41AD48C695D7C54"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookShop;
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


namespace BookShop {
    
    
    /// <summary>
    /// OrderBooks
    /// </summary>
    public partial class OrderBooks : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listBook;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listOrder;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ISBNTxt;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleTxt;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerIdTxt;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox totalPrice;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ISBNShowTxt;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleShowTxt;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceShowTxt;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuantityTxt;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\OrderBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TotalPriceTxt;
        
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
            System.Uri resourceLocater = new System.Uri("/BookShop;component/orderbooks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OrderBooks.xaml"
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
            this.listBook = ((System.Windows.Controls.ListView)(target));
            
            #line 11 "..\..\OrderBooks.xaml"
            this.listBook.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBook_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listOrder = ((System.Windows.Controls.ListView)(target));
            
            #line 21 "..\..\OrderBooks.xaml"
            this.listOrder.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListOrder_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 32 "..\..\OrderBooks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchBook_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 33 "..\..\OrderBooks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBookToCart_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 34 "..\..\OrderBooks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBookFromCart_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 35 "..\..\OrderBooks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Checkout_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ISBNTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TitleTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.CustomerIdTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.totalPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.ISBNShowTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.TitleShowTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.PriceShowTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.QuantityTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\OrderBooks.xaml"
            this.QuantityTxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.QuantityTxt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 53 "..\..\OrderBooks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowMyCart_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.TotalPriceTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            
            #line 58 "..\..\OrderBooks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
