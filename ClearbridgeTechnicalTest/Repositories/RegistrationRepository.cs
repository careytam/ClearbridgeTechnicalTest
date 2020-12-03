using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClearbridgeTechnicalTest.Models
{
    public class RegistrationRepository
    {
        public RegistrationRepository()
        {

        }

        public void Add(Registration registration)
        {

        }

        public void Update(Registration registration)
        {

        }

        public void Delete(int id)
        {

        }

        public IEnumerable<Registration> Get(Func<Registration, bool> condition)
        {
            return new List<Registration>();
        }

        public Registration GetSingle(int id)
        {
            return new Registration();
        }

        public IEnumerable<Registration> GetAll()
        {
            return new List<Registration>();
        }
    }
}