﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DGWebScanner.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5000")]
        public string internetTimeout {
            get {
                return ((string)(this["internetTimeout"]));
            }
            set {
                this["internetTimeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool firstTimeRun {
            get {
                return ((bool)(this["firstTimeRun"]));
            }
            set {
                this["firstTimeRun"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string proxyIPSetting {
            get {
                return ((string)(this["proxyIPSetting"]));
            }
            set {
                this["proxyIPSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string proxyPortSetting {
            get {
                return ((string)(this["proxyPortSetting"]));
            }
            set {
                this["proxyPortSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string proxyUsernameSetting {
            get {
                return ((string)(this["proxyUsernameSetting"]));
            }
            set {
                this["proxyUsernameSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string proxyPasswordSetting {
            get {
                return ((string)(this["proxyPasswordSetting"]));
            }
            set {
                this["proxyPasswordSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("WHITE")]
        public string textShadeColorSetting {
            get {
                return ((string)(this["textShadeColorSetting"]));
            }
            set {
                this["textShadeColorSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Blue")]
        public string primaryColorSetting {
            get {
                return ((string)(this["primaryColorSetting"]));
            }
            set {
                this["primaryColorSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Orange")]
        public string accentColorSetting {
            get {
                return ((string)(this["accentColorSetting"]));
            }
            set {
                this["accentColorSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.2.5.5")]
        public string version {
            get {
                return ((string)(this["version"]));
            }
            set {
                this["version"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LIGHT")]
        public string themeColorSetting {
            get {
                return ((string)(this["themeColorSetting"]));
            }
            set {
                this["themeColorSetting"] = value;
            }
        }
    }
}
