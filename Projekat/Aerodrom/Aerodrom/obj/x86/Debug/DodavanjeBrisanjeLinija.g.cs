﻿#pragma checksum "C:\Users\Lejla\Desktop\Grupa6-piloti\Projekat\Aerodrom\Aerodrom\DodavanjeBrisanjeLinija.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D267461C0ADF8FF7B379732E2C443327"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aerodrom
{
    partial class DodavanjeBrisanjeLinija : 
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
                    global::Windows.UI.Xaml.Controls.ComboBox element1 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 29 "..\..\..\DodavanjeBrisanjeLinija.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)element1).SelectionChanged += this.ComboBox_SelectionChanged;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.ComboBox element2 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 32 "..\..\..\DodavanjeBrisanjeLinija.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)element2).SelectionChanged += this.ComboBox_SelectionChanged;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 43 "..\..\..\DodavanjeBrisanjeLinija.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.Button_Click;
                    #line default
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

