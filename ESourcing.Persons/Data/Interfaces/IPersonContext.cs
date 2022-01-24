using ESourcing.Persons.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Persons.Data.Interfaces
{
    public interface IPersonContext
    {
        IMongoCollection<Person> Persons { get; }
    }
}
