using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClearbridgeTechnicalTest.Models
{
    public class RegistrationRequestRepository
    {
        public RegistrationRequestRepository()
        {

        }

        public void Add(RegistrationRequest registrationRequest)
        {

        }

        public void Update(RegistrationRequest registrationRequest)
        {

        }

        public void Delete(int id)
        {

        }

        public bool DoesEmailExist(string email)
        {
            return false;
        }

        public IEnumerable<RegistrationRequest> Get(Func<RegistrationRequest, bool> condition)
        {
            return new List<RegistrationRequest>();
        }

        public RegistrationRequest GetSingle(int id)
        {
            return new RegistrationRequest();
        }

        public IEnumerable<RegistrationRequest> GetAll()
        {
            return new List<RegistrationRequest>();
        }
    }
}