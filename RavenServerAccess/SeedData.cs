using Raven.Client.Documents;
using RavenDbAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDbAccessLayer
{
    public static class SeedData
    {
        public static void EnsureSeedData(IDocumentStore store)
        {
            using (var session = store.OpenSession())
            {
                // Seed People
                if (!session.Query<Person>().Any())
                {
                    session.Store(new Person { Name = "Wayne Rooney", Age = 39 });
                    session.Store(new Person { Name = "Lionel Messi", Age = 37 });
                }

                // Seed Departments
                if (!session.Query<Department>().Any())
                {
                    session.Store(new Department { Name = "IT", Location = "HQ Building A" });
                    session.Store(new Department { Name = "HR", Location = "Building C" });
                }

                session.SaveChanges();
            }
        }
    }
}
