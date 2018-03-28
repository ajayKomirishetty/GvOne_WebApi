using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GvOne_WebApi.UserViewModel
{
    public class LoanModel
    {
    
            public long tblLoanID { get; set; }
            public string ActualLoanID { get; set; }
            public Nullable<long> PrimaryBorrowerID { get; set; }
            public System.DateTime CreatedAt { get; set; }
            public System.DateTime ModifiedAt { get; set; }
            public Nullable<int> tblLoanStatusID { get; set; }

        }
    }

