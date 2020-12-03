using System;
using System.Collections.Generic;

namespace ClearbridgeTechnicalTest.Models
{
    public class LoginVerificationCodeRepository
    {
        public LoginVerificationCodeRepository()
        {

        }

        public void Add(LoginVerificationCode loginVerificationCode)
        {

        }

        public void Update(LoginVerificationCode loginVerificationCode)
        {

        }

        public void Delete(int id)
        {

        }

        public IEnumerable<LoginVerificationCode> Get(Func<LoginVerificationCode, bool> condition)
        {
            return new List<LoginVerificationCode>();
        }

        public LoginVerificationCode GetSingle(int id)
        {
            return new LoginVerificationCode();
        }

        public IEnumerable<LoginVerificationCode> GetAll()
        {
            return new List<LoginVerificationCode>();
        }
    }
}