﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLMamNon.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("server=localhost;User Id=root;Password=root;Persist Security Info=True;database=q" +
            "lmamnon;Character Set=utf8;Allow Zero Datetime=True;Convert Zero Datetime=True")]
        public string qlmamnonConnectionString1 {
            get {
                return ((string)(this["qlmamnonConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2017-06-06")]
        public global::System.DateTime AppLannchDate {
            get {
                return ((global::System.DateTime)(this["AppLannchDate"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Thực phẩm, Phụ phí")]
        public string DefaultMaPhanLoaiChi {
            get {
                return ((string)(this["DefaultMaPhanLoaiChi"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://rest.esms.vn/MainService.svc/json/SendMultipleMessage_V4_get?Phone={0}&Con" +
            "tent={1}&ApiKey=9BB708A18DC3EE2D63879D0D2E55CC&SecretKey=27AD94C5BC577605E8D26BC" +
            "DBF086F&SmsType=4&IsUnicode=0")]
        public string SMSWSSendMessageUrl {
            get {
                return ((string)(this["SMSWSSendMessageUrl"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6000")]
        public long TienAnSang {
            get {
                return ((long)(this["TienAnSang"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6000")]
        public long TienAnToi {
            get {
                return ((long)(this["TienAnToi"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20000")]
        public long TienAnChinh {
            get {
                return ((long)(this["TienAnChinh"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2015")]
        public int StartYearForDropDown {
            get {
                return ((int)(this["StartYearForDropDown"]));
            }
        }
    }
}
