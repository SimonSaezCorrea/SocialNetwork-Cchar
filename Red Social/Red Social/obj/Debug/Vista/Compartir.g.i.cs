﻿#pragma checksum "..\..\..\Vista\Compartir.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "70442F17E74B65FB831F6C118D941BE0A56C20A68054057624DFE8EE85D1A51F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Red_Social;
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


namespace Red_Social {
    
    
    /// <summary>
    /// Compartir
    /// </summary>
    public partial class Compartir : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Vista\Compartir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListUser;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Vista\Compartir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListUser_Elegidos;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Vista\Compartir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Elegir;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Vista\Compartir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Retornar;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Vista\Compartir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Acetar;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Vista\Compartir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/Red Social;component/vista/compartir.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vista\Compartir.xaml"
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
            this.ListUser = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.ListUser_Elegidos = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.Elegir = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Vista\Compartir.xaml"
            this.Elegir.Click += new System.Windows.RoutedEventHandler(this.Elegir_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Retornar = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Vista\Compartir.xaml"
            this.Retornar.Click += new System.Windows.RoutedEventHandler(this.Retornar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Acetar = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Vista\Compartir.xaml"
            this.Acetar.Click += new System.Windows.RoutedEventHandler(this.Acetar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Cancelar = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Vista\Compartir.xaml"
            this.Cancelar.Click += new System.Windows.RoutedEventHandler(this.Cancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

