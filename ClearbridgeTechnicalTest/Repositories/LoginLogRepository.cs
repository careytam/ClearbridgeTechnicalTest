using System;
using System.Collections.Generic;

namespace ClearbridgeTechnicalTest.Models
{
    public class LoginLogRepository
    {
        public LoginLogRepository()
        {

        }

        public void Add(LoginLog loginLog)
        {

        }

        public void Update(LoginLog loginLog)
        {

        }

        public void Delete(int id)
        {

        }

        public IEnumerable<LoginLog> Get(Func<LoginLog, bool> condition)
        {
            return new List<LoginLog>();
        }

        public LoginLog GetLastestLoginLog(string email)
        {
            return new LoginLog();
        }

        public LoginLog GetSingle(int id)
        {
            return new LoginLog();
        }

        public IEnumerable<LoginLog> GetAll()
        {
            return new List<LoginLog>();
        }
    }
}