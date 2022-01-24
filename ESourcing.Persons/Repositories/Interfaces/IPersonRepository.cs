using ESourcing.Persons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Persons.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPersons();
        Task<Person> GetPerson(string id);

        Task Create(Person person);
        Task<Person> CreatePerson(Person personCreateCommand);
        Task<bool> Update(Person person);
        Task<bool> Delete(string id);

    }
}
