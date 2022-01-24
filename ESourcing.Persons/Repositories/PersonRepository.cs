using ESourcing.Persons.Data.Interfaces;
using ESourcing.Persons.Entities;
using ESourcing.Persons.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Persons.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly IPersonContext _context;

        public PersonRepository(IPersonContext context)
        {
            _context = context;
        }
        public async Task Create(Person person)
        {
            await _context.Persons.InsertOneAsync(person);
        }

        public async Task<Person> CreatePerson(Person person)
        {
             await _context.Persons.InsertOneAsync(person);
             return person;
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Person>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _context.Persons.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Person> GetPerson(string id)
        {
            return await _context.Persons.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _context.Persons.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Person person)
        {
            var updateResult = await _context.Persons.ReplaceOneAsync(filter: p => p.Id == person.Id, replacement: person);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
