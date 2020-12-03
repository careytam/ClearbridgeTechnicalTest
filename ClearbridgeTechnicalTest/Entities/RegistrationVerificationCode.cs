using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClearbridgeTechnicalTest.Models
{
    public class RegistrationVerificationCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public RegistrationRequest RegistrationRequest { get; set; }
        public DateTime CreatedDatetime { get; set; }

        public RegistrationVerificationCode()
        {
            this.Generate();
        }

        public void Add()
        {
            RegistrationVerificationCodeRepository registrationVerificationCodeRepository = new RegistrationVerificationCodeRepository();
            registrationVerificationCodeRepository.Add(this);
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        protected string Generate()
        {
            //assuming that a new verification code gets generated on the spot of instatiating the object
            //Generate verification code

            return string.Empty;
        }

        public bool IsWithin24Hours()
        {
            return false;
        }

        public void ResendRegistrationVerificationCodeEmail()
        {

        }
    }
}