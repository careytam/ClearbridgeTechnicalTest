using ClearbridgeTechnicalTest.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Security;

namespace ClearbridgeTechnicalTest.Controllers
{
    public class LoginController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        public bool Login(LoginModel login)
        {
            RegistrationRequest registrationRequest = login.GetRegistrationRequest();

            if (login.Validate())
            {
                LoginLog loginLog = new LoginLog()
                {
                    RegistrationRequest = registrationRequest
                };

                if (registrationRequest.DualFactorAuthentication)
                {
                    loginLog.GenerateVerificationCode();
                    loginLog.Add();
                    loginLog.SendDualFactorAuthenticationEmail();
                }
                else
                {
                    loginLog.Add();
                    FormsAuthentication.SetAuthCookie(loginLog.RegistrationRequest.Email, false);
                }

                return true;
            }
            else
                return false;
            
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AllowAnonymous]
        public bool IsDualFactorAuthentication(string email)
        {
            RegistrationRequestRepository registrationRequestRepository = new RegistrationRequestRepository();
            RegistrationRequest registrationRequest = registrationRequestRepository.Get(rr => rr.Email == email).FirstOrDefault();

            return registrationRequest.DualFactorAuthentication;
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        public bool ValidateVerficationCode(LoginVerificationCodeModel logonWithVerificationModel)
        {
            if (logonWithVerificationModel.Validate())
            {
                FormsAuthentication.SetAuthCookie(logonWithVerificationModel.Email, false);

                return true;
            }
            else
                return false;
        }
    }
}