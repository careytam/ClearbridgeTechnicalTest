using System.Collections.Generic;
using System.Linq;

namespace ClearbridgeTechnicalTest.Models
{
    public class RegistrationRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CreatedDatetime { get; set; }
        public string RoleName { get; set; }
        public bool DualFactorAuthentication { get; set; }
        public RegistrationVerificationCode LatestRegistrationVerificationCode
        {
            get
            {
                return this.registrationVerificationCodes.OrderBy(rvc => rvc.CreatedDatetime).LastOrDefault();
            }
        }
        protected ICollection<RegistrationVerificationCode> registrationVerificationCodes { get; set; }

        public RegistrationRequest()
        {
            //For new RegistrationRequest
            this.registrationVerificationCodes = new List<RegistrationVerificationCode>();
        }

        public void Load()
        {
            RegistrationVerificationCodeRepository registrationVerificationCodeRepository = new RegistrationVerificationCodeRepository();

            this.registrationVerificationCodes = registrationVerificationCodeRepository.Get(rvc => rvc.RegistrationRequest.Email == this.Email).ToList();
        }

        public void Add()
        {
            RegistrationRequestRepository registrationRequestRepository = new RegistrationRequestRepository();
            RegistrationVerificationCode registrationVerificationCode = new RegistrationVerificationCode();

            if (!registrationRequestRepository.DoesEmailExist(this.Email))
            {
                registrationVerificationCode.Add();
                this.registrationVerificationCodes.Add(registrationVerificationCode);
                registrationRequestRepository.Add(this);
            }
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        public bool ValidateRegistrationRequestExist()
        {
            return false;
        }

        public void SendRegistrationEmail()
        {
            //Take the information in this object and in the RegistrationVerificationCode
            //to create a registration email and then send
        }

        public bool IsValidEmailAlreadyExisting()
        {
            return false;
        }

        public bool IsRegisteredYet()
        {
            return false;
        }

        public bool DoesVerificationCodeMatch(string verificationCode)
        {
            return this.LatestRegistrationVerificationCode.Code == verificationCode;
        }

        public bool HasHad5VerficationCodeSentYet()
        {
            return this.registrationVerificationCodes.Count() == 5;
        }
    }
}