using System;
using System.Collections.Generic;

namespace ClearbridgeTechnicalTest.Models
{
    public class RegistrationVerificationCodeRepository
    {
        public RegistrationVerificationCodeRepository()
        {

        }

        public void Add(RegistrationVerificationCode registrationVerificationCode)
        {

        }

        public void Update(RegistrationVerificationCode registrationVerificationCode)
        {

        }

        public void Delete(int id)
        {

        }

        public bool DoesVerificationCodeExist()
        {
            //used to generate verification codes
            return false;
        }

        public RegistrationVerificationCode GetSingle(int id)
        {
            return new RegistrationVerificationCode();
        }

        public IEnumerable<RegistrationVerificationCode> Get(Func<RegistrationVerificationCode, bool> condition)
        {
            return new List<RegistrationVerificationCode>();
        }

        public IEnumerable<RegistrationVerificationCode> GetAll()
        {
            return new List<RegistrationVerificationCode>();
        }
    }
}