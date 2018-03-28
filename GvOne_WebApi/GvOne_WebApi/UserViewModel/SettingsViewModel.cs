using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GvOne_WebApi.UserViewModel
{
    public class SettingsViewModel
    {
        public bool isAllSettingsEnabled { get; set; }
        public bool isPushNotificationsEnabled { get; set; }
        public bool isAlertsEnabled { get; set; }

    }
}