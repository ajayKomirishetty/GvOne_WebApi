//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GvOne_WebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSetting
    {
        public long tblSettingID { get; set; }
        public Nullable<long> Uid { get; set; }
        public bool isAllSettingsEnabled { get; set; }
        public bool isPushNotificationsEnabled { get; set; }
        public bool isAlertsEnabled { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}
