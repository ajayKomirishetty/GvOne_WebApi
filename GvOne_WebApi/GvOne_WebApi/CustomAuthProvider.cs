using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GvOne_WebApi
{
    internal class CustomAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            await Task.Run(() => { });
        }
        //public override async Task GrantRefreshToken()
        //{

        //}
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (GvOneDbEntities db = new GvOneDbEntities())
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                var user = db.tblUsers.FirstOrDefault(x => x.Email.Equals(context.UserName) && x.Password.Equals(context.Password));            
                //string[] roles = db.tblUserLoans.Where(x => x.Uid.Equals(user.Uid)).Select(x => x.tblRole.Name).ToArray();
                var roles = user.tblRoles.ToList();
                if (user != null)
                {
                    foreach (var role in roles)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                     //   identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Uid.ToString()));
                        identity.AddClaim(new Claim("UserID", user.Uid.ToString()));
                        identity.AddClaim(new Claim("UserRole",user.tblRoles.Select(p=>p.Name.ToString()).First()));
                    }
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("Message", "invalid credentials");
                }
                await Task.Run(() => { });
            }
        }
    }
}