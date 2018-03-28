using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GvOne_WebApi.UserViewModel
{
    public class LoanViewModel
    {
        public string PrimaryBorrowerName { get; set; }
        public string Address { get; set; }
        public string LoanId { get; set; }
    }
}