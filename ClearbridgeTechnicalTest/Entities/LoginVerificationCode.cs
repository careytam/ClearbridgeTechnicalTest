using System;

namespace ClearbridgeTechnicalTest.Models
{
    public class LoginVerificationCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public LoginLog LoginLog { get; set; }
        public DateTime CreatedDatetime { get; set; }

        public LoginVerificationCode()
        {
            this.Generate();
        }

        public void Add()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        protected void Generate()
        {
            //assuming that a new verification code gets generated on the spot of instatiating the object
            //Generate verification code
        }
    }
}