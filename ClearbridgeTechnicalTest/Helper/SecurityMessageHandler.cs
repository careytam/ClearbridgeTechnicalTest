using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace ClearbridgeTechnicalTest.Models
{
    public class SecurityMessageHandler : DelegatingHandler
    {
        public SecurityMessageHandler() :base()
        {

        }

        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                //This is where the roles are set for the logged in user
                //A role based provider class has to be written to return the role of the 
                //current logged in user and have it used here

                GenericIdentity identity = new GenericIdentity(HttpContext.Current.User.Identity.Name);
                IPrincipal principal = new GenericPrincipal(identity, new[] { "Admin" });
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}