using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GvOne_WebApi.UserViewModel
{
    public class UserLoanModel
    {
            public long Uid { get; set; }
            public long tblLoanID { get; set; }
            public int Rid { get; set; }

            public virtual tblLoan tblLoan { get; set; }
            public virtual tblRole tblRole { get; set; }
            public virtual tblUser tblUser { get; set; }
        }
    }

