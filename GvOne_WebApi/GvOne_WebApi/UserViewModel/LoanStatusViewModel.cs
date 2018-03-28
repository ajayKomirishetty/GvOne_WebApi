using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GvOne_WebApi.UserViewModel
{
    public class LoanStatusViewModel
    {
        public string PrimaryBorrowerName { get; set; }
        public string ActualLoanID { get; set; }
        public string Address { get; set; }
    
        public string Description { get; set; }
        public string Label { get; set; }
       // public bool IsActive { get; set; }

        public ICollection<UserModel> Borrowers { get; set; }

        public UserModel Agent { get; set; }
    }
}