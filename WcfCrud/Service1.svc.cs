using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCrud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        PersonContext db = new PersonContext();
        public void DeletePerson(Person per)
        {
            var ps = db.Person.Find(per.ID);
            db.Person.Remove(ps);
            db.SaveChanges();
        }

        public IEnumerable<Person> GetPerson()
        {
            List<Person> ps = new List<Person>();
            ps = db.Person.ToList();
            return ps;
        }

        public Person GetPersonById(string id)
        {
            var i = Convert.ToInt32(id);
            var ps = db.Person.Find(i);
            return ps;
        }

        public void InsertPerson(Person per)
        {
            db.Person.Add(per);
            db.SaveChanges();
        }

        public void UpdatetPerson(Person per)
        {
            Person ps = new Person();
            ps.ID = per.ID;
            ps.Name = per.Name;
            ps.Age = per.Age;
            ps.Address = per.Address;
            db.Entry(ps).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
