using System.Linq;

namespace ClearbridgeTechnicalTest.Models
{
    public class LoginModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public LoginModel()
        {

        }

        public virtual bool Validate()
        {
            RegistrationRequestRepository registrationRequestRepository = new RegistrationRequestRepository();
            RegistrationRequest registrationRequest = registrationRequestRepository.Get(rr => rr.Email == this.Email).FirstOrDefault();
            RegistrationRepository registrationRepository = new RegistrationRepository();
            Registration registration = registrationRepository.Get(r => r.RegistrationRequest.Id == registrationRequest.Id).FirstOrDefault();

            return registrationRequest.Email == this.Email && registration.password == this.Password;
        }

        public RegistrationRequest GetRegistrationRequest()
        {
            //Get registration request from email property
            return new RegistrationRequest();
        }

        public Registration GetRegistration()
        {
            //Get RegistrationRequest and then using the RegistrationRequest.Id to get Registration 
            //object with the help of the RegistrationRepository
            return new Registration();
        }
    }
}