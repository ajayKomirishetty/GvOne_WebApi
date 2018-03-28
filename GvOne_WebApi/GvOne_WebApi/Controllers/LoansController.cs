using GvOne_WebApi.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace GvOne_WebApi.Controllers
{
    [Authorize(Roles="Admin")]

    public class LoansController : ApiController
    {
        /// <summary>
        /// /retrieves all the loans
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LoanViewModel> GetLoans()
        {
          //  var r= User.IsInRole("Admin");
            using (GvOneDbEntities db = new GvOneDbEntities())
            {
                var users = db.tblLoans.Select(
            x => new LoanViewModel()
            {
                PrimaryBorrowerName = x.tblUser.Name,
                LoanId = x.ActualLoanID,
                Address = x.tblUser.Address
            }).ToList();
                return users;
            }
        }
        //  [Route("~/api/display/getloaninfobyid")]
        [HttpGet]
        public int GetUserId()
        {
            //var iden = User.Identity as ClaimsIdentity;
            //var userid = iden.FindFirst(ClaimTypes.NameIdentifier);
            //return (userid != null) ? Convert.ToInt16(userid.Value) : 0;
            return User.Identity.GetClientId();
        }
        [HttpGet]
        public string testRole()
        {
            return User.Identity.GetClientRole();
        }

        /// <summary>
        /// gets alerts by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UserAlertModel> GetAlerts()
        {
            using (GvOneDbEntities db = new GvOneDbEntities())
            {
                int userId = GetUserId();
                return db.tblUserAlerts.Where(x => x.Uid == userId && x.IsRead==false && x.IsDeleted==false).Select(
                x => new UserAlertModel()
                {
                    AlertID = x.tblAlertID,
                    Description = x.tblAlert.Description,
                    Subject = x.tblAlert.Subject,
                }
        ).ToList();
            }
        }

        /// <summary>
        /// gets settings by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        
            [Route("~/Api/loans/GetSettingByUserId")]
        public SettingsViewModel GetSettings()
        {
            using (GvOneDbEntities db = new GvOneDbEntities())
            {
                int userId = GetUserId();
                return db.tblSettings.Where(x => x.tblUser.Uid == userId).Select(
                x => new SettingsViewModel()
                {
                    isAlertsEnabled = x.isAlertsEnabled,
                    isAllSettingsEnabled = x.isAllSettingsEnabled,
                    isPushNotificationsEnabled = x.isPushNotificationsEnabled,
                }).First();
            }
        }

        /// <summary>
        /// gets loanInfo By userID
        /// </summary>
        /// <param name="actualLoanId"></param>
        /// <returns></returns>
        public LoanStatusViewModel GetLoanInfoById(string actualLoanId)
        {
            using (GvOneDbEntities db = new GvOneDbEntities())
            {
                return db.tblLoans.Where(x => x.ActualLoanID == actualLoanId.ToString()).Select(
                x => new LoanStatusViewModel()
                {
                    PrimaryBorrowerName = x.tblUser.Name,
                    ActualLoanID = x.ActualLoanID,
                    Address = x.tblUser.Address,
                    Label = x.tblLoanStatu.Label,
                    Description = x.tblLoanStatu.Description,
                    Agent = x.tblUserLoans.Where(y => y.tblRole.Name.Equals("agent")).Select(
                        y => new UserModel
                        {
                            Email = y.tblUser.Email,
                            Name = y.tblUser.Name,
                            Mobile = y.tblUser.Mobile,

                        }).FirstOrDefault(),
                    Borrowers = x.tblUserLoans.Where(y => y.tblRole.Name.Equals("borrower")).Select(
                        y => new UserModel
                        {
                            Email = y.tblUser.Email,
                            Name = y.tblUser.Name,
                            Mobile = y.tblUser.Mobile,
                        }).ToList(),

                }).FirstOrDefault();
            }
        }

    }
}
