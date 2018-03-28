using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GvOne_WebApi.Controllers
{
    public class AccountController : ApiController
    {
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage GetUserDetails(string email, string password)
        {
            using (GvOneDbEntities db = new GvOneDbEntities())
            {
                var user = db.tblUsers.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
                string[] roles = db.tblUserLoans.Where(x => x.Uid.Equals(user.Uid)).Select(x => x.tblRole.Name).ToArray();
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Invalid email or password.");
                }

                //RequestContext.Principal = new GenericPrincipal(
                //        new GenericIdentity(user.Email, "Form"),
                //        roles
                //    );
                ////FormsAuthentication.SetAuthCookie(user.Email, false);
                return Request.CreateResponse(HttpStatusCode.OK, user.Name);
            }
        }
    }
}

