﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TreeView.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\ZHUANGPEI;Initial Catalog=Harvest;User Id=sa;Password=Ytogroup12345" +
            "67")]
        public string HarvestConnectionString {
            get {
                return ((string)(this["HarvestConnectionString"]));
            }
            set {
                this["HarvestConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\ZHUANGPEI;Initial Catalog=Harvest;User Id=sa;Password=ytofdh;Integr" +
            "ated Security=False")]
        public string TempLocal {
            get {
                return ((string)(this["TempLocal"]));
            }
            set {
                this["TempLocal"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.1.35\\ZHUANGPEI;Initial Catalog=Harvest;User Id=sa;Password=Yt" +
            "ogroup1234567")]
        public string TempIP {
            get {
                return ((string)(this["TempIP"]));
            }
            set {
                this["TempIP"] = value;
            }
        }
    }
}
