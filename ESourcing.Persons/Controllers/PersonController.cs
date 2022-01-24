using ESourcing.Persons.Entities;
using ESourcing.Persons.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ESourcing.Persons.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region Variables

        private readonly IPersonRepository _personRepository;
        private readonly ILogger<PersonController> _logger;
        private readonly IMediator _mediator;

        #endregion

        #region Contructor

        public PersonController(IPersonRepository personRepository,ILogger<PersonController> logger, IMediator mediator)
        {
            _personRepository = personRepository;
            _logger = logger;
            _mediator = mediator;
        }

        #endregion

        #region Crud_Actions

        [HttpGet]
        [ProducesResponseType(typeof(Person),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _personRepository.GetPersons();
            return Ok(persons);
        }

        [HttpGet("{id:length(24)}",Name ="GetPerson")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            var person = await _personRepository.GetPerson(id);

            if (person == null)
            {
                _logger.LogError($"{id} sahip bir person bulunamadı.");
                return NotFound();
            }
            return Ok(person);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Person>> CretaePerson([FromBody] Person person)
        {
            await _personRepository.Create(person);
            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdatePerson([FromBody] Person person)
        {
            return Ok(await _personRepository.Update(person));

        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeletePersonById(string id)
        {
            return Ok(await _personRepository.Delete(id));
        }


        //[HttpGet("GetPersonsByName/{name}")]
        ////[HttpGet("GetPersonsByName")]
        //[ProducesResponseType(typeof(IEnumerable<PersonResponse>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPersonsByName(string name)
        //{
        //    var query = new GetPersonsNameQuery(name);

        //    var persons = await _mediator.Send(query);

        //    if (persons.Count() == decimal.Zero)
        //        return NotFound();

        //    return Ok(persons);

        //}

        //[HttpPost("PersonCreate")]
        //[ProducesResponseType(typeof(PersonResponse), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<PersonResponse>> PersonCreate([FromBody] PersonCreateCommand command)
        //{
        //    var result = await _mediator.Send(command);

        //    return Ok(result);
        //}
        #endregion
    }
}
