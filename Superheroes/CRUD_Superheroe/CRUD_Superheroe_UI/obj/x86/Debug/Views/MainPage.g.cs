﻿#pragma checksum "C:\Users\Joker\Desktop\Superheroes\CRUD_Superheroe\CRUD_Superheroe_UI\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3C3BC8B9C2989A15CAACE01BCEF0B3D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Superheroe_UI
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::CRUD_Superheroe_UI.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.PersonPicture obj5;

            // Fields for each event bindings event handler.
            private global::Windows.UI.Xaml.Input.TappedEventHandler obj5Tapped;

            // Static fields for each binding's enabled/disabled state

            public MainPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 65 && columnNumber == 47)
                {
                    this.obj5.Tapped -= obj5Tapped;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 5: // Views\MainPage.xaml line 65
                        this.obj5 = (global::Windows.UI.Xaml.Controls.PersonPicture)target;
                        this.obj5Tapped = (global::System.Object p0, global::Windows.UI.Xaml.Input.TappedRoutedEventArgs p1) =>
                        {
                            this.dataRoot.viewModel.PersonPicture01_Tapped(p0, p1);
                        };
                        ((global::Windows.UI.Xaml.Controls.PersonPicture)target).Tapped += obj5Tapped;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::CRUD_Superheroe_UI.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::CRUD_Superheroe_UI.MainPage obj, int phase)
            {
                if (obj != null)
                {
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\MainPage.xaml line 18
                {
                    this.StackPanelMenuBar = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // Views\MainPage.xaml line 28
                {
                    this.StackPanelBotones = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // Views\MainPage.xaml line 36
                {
                    this.StackPanel01 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // Views\MainPage.xaml line 65
                {
                    this.PersonPicture01 = (global::Windows.UI.Xaml.Controls.PersonPicture)(target);
                }
                break;
            case 6: // Views\MainPage.xaml line 67
                {
                    this.grid01 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 7: // Views\MainPage.xaml line 81
                {
                    this.txtBlockNombre = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Views\MainPage.xaml line 82
                {
                    this.txtErrorNombre = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Views\MainPage.xaml line 83
                {
                    this.txtBlockApellidos = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // Views\MainPage.xaml line 84
                {
                    this.txtErrorApellidos = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // Views\MainPage.xaml line 85
                {
                    this.txtBlockApodo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // Views\MainPage.xaml line 86
                {
                    this.txtErrorApodo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // Views\MainPage.xaml line 87
                {
                    this.txtBlockSexo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // Views\MainPage.xaml line 88
                {
                    this.txtErrorSexo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // Views\MainPage.xaml line 96
                {
                    this.txtCreacionSuperheroe = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Views\MainPage.xaml line 99
                {
                    this.txtBoxNombre = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 17: // Views\MainPage.xaml line 100
                {
                    this.txtBoxApellidos = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 18: // Views\MainPage.xaml line 101
                {
                    this.txtBoxApodo = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 19: // Views\MainPage.xaml line 102
                {
                    this.txtBoxSexo = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 20: // Views\MainPage.xaml line 91
                {
                    this.btnSaveHero = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 21: // Views\MainPage.xaml line 92
                {
                    this.btnDeleteHero = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 22: // Views\MainPage.xaml line 37
                {
                    this.ListView01 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 23: // Views\MainPage.xaml line 47
                {
                    this.ListView02 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListView02).RightTapped += this.ListView01_RightTapped;
                }
                break;
            case 25: // Views\MainPage.xaml line 58
                {
                    this.Actions_Persona_Flyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 27: // Views\MainPage.xaml line 29
                {
                    this.btnAddPerson = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 28: // Views\MainPage.xaml line 30
                {
                    this.btnSavePerson = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 29: // Views\MainPage.xaml line 31
                {
                    this.btnDeletePerson = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 30: // Views\MainPage.xaml line 32
                {
                    this.btnRefreshList = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 31: // Views\MainPage.xaml line 33
                {
                    this.txtSearch = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 32: // Views\MainPage.xaml line 34
                {
                    this.btnSearch = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 33: // Views\MainPage.xaml line 19
                {
                    if (MainPage.IsApiContractPresent_Windows_Foundation_UniversalApiContract_7)
                    {
                        this.Archivo01 = (global::Windows.UI.Xaml.Controls.MenuBar)(target);
                    }
                }
                break;
            case 34: // Views\MainPage.xaml line 21
                {
                    this.btnAddSuperheroe = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                }
                break;
            case 35: // Views\MainPage.xaml line 107
                {
                    this.VisualStateGroup01 = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 36: // Views\MainPage.xaml line 108
                {
                    this.Normal01 = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 37: // Views\MainPage.xaml line 137
                {
                    this.Phone01 = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }

        // Api Information for conditional namespace declarations
        internal static bool IsApiContractPresent_Windows_Foundation_UniversalApiContract_7 = global::Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7);
    }
}
