﻿#pragma checksum "C:\Users\James\source\repos\Kodo\Kodo\View\CreateAccountView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ED0C37D3AAEDC156523BBE0868A54263"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kodo
{
    partial class CreateAccountView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.Background = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.errorBox = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 3:
                {
                    this.successBox = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 4:
                {
                    this.usernameBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.emailBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.passwordBox = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 7:
                {
                    this.confirmPasswordBox = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 8:
                {
                    this.createAccountButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 26 "..\..\..\View\CreateAccountView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.createAccountButton).Click += this.CreateAccount_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.loginButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 27 "..\..\..\View\CreateAccountView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.loginButton).Click += this.Login_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.BackgroundDark = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 11:
                {
                    this.successText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.errorText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

