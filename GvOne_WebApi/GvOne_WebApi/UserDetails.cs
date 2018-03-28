using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace GvOne_WebApi
{
    public static class UserDetails
    {
        public static int GetClientId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserID");
            return (claim != null) ? Convert.ToInt16(claim.Value) : 0;
        }
        public static String GetClientRole(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserRole");
            return (claim != null) ? claim.Value : "null";
        }
    }
}