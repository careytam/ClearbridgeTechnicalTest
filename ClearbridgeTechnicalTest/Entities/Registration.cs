using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClearbridgeTechnicalTest.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string password { get; set; }
        public RegistrationRequest RegistrationRequest { get; set; }
        public RegistrationVerificationCode RegistrationVerificationCode { get; set; }
        public DateTime RegisteredDatetime { get; set; }

        public Registration()
        { 
        
        }

        public void Add()
        {
            RegistrationRepository registrationRepository = new RegistrationRepository();
            registrationRepository.Add(this);
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        public static IEnumerable<string> ValidatePassword(string Password)
        {
            return new List<string>();
        }
    }
}