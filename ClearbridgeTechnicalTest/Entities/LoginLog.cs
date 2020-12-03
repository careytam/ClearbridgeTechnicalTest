using System;

namespace ClearbridgeTechnicalTest.Models
{
    public class LoginLog
    {
        public int Id { get; set; }
        public RegistrationRequest RegistrationRequest { get; set;}
        public LoginVerificationCode LoginVerificationCode { get; set; }
        public DateTime LoginDatetime { get; set; }
        
        public LoginLog()
        {

        }

        public void Add()
        {

        }

        public void GenerateVerificationCode()
        {
            this.LoginVerificationCode = new LoginVerificationCode();
            this.LoginVerificationCode.LoginLog = this;
        }

        public void SendDualFactorAuthenticationEmail()
        {

        }
    }
}