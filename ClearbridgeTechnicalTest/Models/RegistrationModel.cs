using ClearbridgeTechnicalTest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClearbridgeTechnicalTest.Models
{
    public class RegistrationModel : LoginVerificationCodeModel
    {
        public string RoleName { get; set; }
        public RegistrationModel() : base()
        {

        }

        
    }
}