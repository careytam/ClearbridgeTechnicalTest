using ClearbridgeTechnicalTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Security;

namespace ClearbridgeTechnicalTest.Controllers
{
    public class RegistrationController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        [Authorize(Roles = "Admin, CustomerRep")]
        public void CreateRegistration([FromUri] string email, [FromUri] string roleName, [FromUri] bool dualFactorAuthentication)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest();
            registrationRequest.Email = email;
            registrationRequest.RoleName = roleName;
            registrationRequest.DualFactorAuthentication = dualFactorAuthentication;

            if (!registrationRequest.IsValidEmailAlreadyExisting())
            {
                registrationRequest.Add();
                registrationRequest.SendRegistrationEmail();
            }
            else
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
        }

        [System.Web.Mvc.HttpPost]
        [AllowAnonymous]
        public bool ValidateEmail([FromUri] string email)
        {
            //Check datebase to see if email exist and not registered yet
            RegistrationRequestRepository registrationRequestRepository = new RegistrationRequestRepository();
            RegistrationRequest registrationRequest = registrationRequestRepository.Get(rr => rr.Email == email).FirstOrDefault();

            return !registrationRequest.IsRegisteredYet() && registrationRequest.IsValidEmailAlreadyExisting();
        }

        [System.Web.Mvc.HttpGet]
        [AllowAnonymous]
        public bool HasHad5VerficationCodeSentYet(string email)
        {
            RegistrationRequestRepository registrationRequestRepository = new RegistrationRequestRepository();
            RegistrationRequest registrationRequest = registrationRequestRepository.Get(rr => rr.Email == email).FirstOrDefault();

            return registrationRequest.HasHad5VerficationCodeSentYet();
        }

        [System.Web.Mvc.HttpPost]
        [AllowAnonymous]
        public IEnumerable<string> ValidatePassword([FromBody] string password)
        {
            //check against password rules, but I argue that password checking can be performed on the 
            //level of client side validation
            //returns a list of errors, if successful, the count of the list return should be 0
            return Registration.ValidatePassword(password);
        }

        [System.Web.Mvc.HttpPost]
        [AllowAnonymous]
        public void ResendVerificationCode([FromUri] string email)
        {
            RegistrationRequestRepository registrationRequestRepository = new RegistrationRequestRepository();
            RegistrationRequest registrationRequest = registrationRequestRepository.Get(rr => rr.Email == email).FirstOrDefault();
            RegistrationVerificationCode registrationVerificationCode = new RegistrationVerificationCode();

            if (registrationRequest.IsValidEmailAlreadyExisting() && !registrationRequest.IsRegisteredYet())
            {
                registrationVerificationCode.RegistrationRequest = registrationRequest;
                registrationVerificationCode.Add();
                registrationVerificationCode.ResendRegistrationVerificationCodeEmail();
            }
            else
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
        }

        [System.Web.Mvc.HttpPost]
        [AllowAnonymous]
        public void CreateRegistration(RegistrationModel registrationModel)
        {
            RegistrationRequestRepository registrationRequestRepository = new RegistrationRequestRepository();
            RegistrationRequest registrationRequest = registrationRequestRepository.Get(rr => rr.Email == registrationModel.Email).FirstOrDefault();
            RegistrationVerificationCodeRepository registrationVerificationCodeRepository = new RegistrationVerificationCodeRepository();
            RegistrationVerificationCode registrationVerificationCode = registrationVerificationCodeRepository.Get(rvc => rvc.Code == registrationModel.VerificationCode).FirstOrDefault();
            Registration registration;

            if (registrationRequest.IsValidEmailAlreadyExisting() && !registrationRequest.IsRegisteredYet() 
                && registrationRequest.DoesVerificationCodeMatch(registrationModel.VerificationCode) 
                && registrationRequest.LatestRegistrationVerificationCode.IsWithin24Hours())
            {
                registration = new Registration();
                registration.RegistrationRequest = registrationRequest;
                registration.RegistrationVerificationCode = registrationVerificationCode;
                registration.password = registrationModel.Password;
                registration.Add();

                FormsAuthentication.SetAuthCookie(registrationModel.Email, false);
            }
            else
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            
        }
    }
}