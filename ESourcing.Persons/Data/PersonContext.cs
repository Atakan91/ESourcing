using ESourcing.Persons.Data.Interfaces;
using ESourcing.Persons.Entities;
using ESourcing.Persons.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Persons.Data
{
    public class PersonContext : IPersonContext
    {
        public PersonContext(IPersonDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Persons = database.GetCollection<Person>(settings.CollectionName);

            PersonContextSeed.SeedData(Persons);
        }
        public IMongoCollection<Person> Persons { get ;  }
      

    }
}
