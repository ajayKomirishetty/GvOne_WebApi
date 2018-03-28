using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;


[assembly: OwinStartup(typeof(GvOne_WebApi.Startup))]

namespace GvOne_WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
                var provider = new CustomAuthProvider();

                OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = provider,
                    RefreshTokenProvider = new RefreshTokenProvider()

                };

                app.UseOAuthAuthorizationServer(options);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

                HttpConfiguration config = new HttpConfiguration();
                WebApiConfig.Register(config);
            }
        }
    }
