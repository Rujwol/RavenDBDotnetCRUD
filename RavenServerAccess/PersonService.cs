using RavenDbAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDbAccessLayer
{
    public class PersonService
    {
        public void AddPerson(Person person)
        {
            using var session = RavenDbStore.Store.OpenSession();
            session.Store(person);
            session.SaveChanges();
        }

        public List<Person> GetAllPeople()
        {
            using var session = RavenDbStore.Store.OpenSession();
            return session.Query<Person>().ToList();
        }
        public Person GetPersonById(string id)
        {
            using var session = RavenDbStore.Store.OpenSession();
            return session.Load<Person>(id);
        }

        public void UpdatePerson(Person updatedPerson)
        {
            using var session = RavenDbStore.Store.OpenSession();
            var person = session.Load<Person>(updatedPerson.Id);
            if (person == null) return;

            person.Name = updatedPerson.Name;
            person.Age = updatedPerson.Age;

            session.SaveChanges();
        }

        public void DeletePerson(string id)
        {
            using var session = RavenDbStore.Store.OpenSession();
            var person = session.Load<Person>(id);
            if (person == null) return;

            session.Delete(person);
            session.SaveChanges();
        }
    }
}
