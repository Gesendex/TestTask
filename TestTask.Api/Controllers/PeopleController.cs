using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Interfaces;
using TestTask.Models;

namespace TestTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        [HttpGet("GetPeople")]
        public ActionResult<IEnumerable<Person>> GetPeople(string sex, int? x, int? y, int start = 0, int count = 50)
        {
            var people = _peopleRepository.GetPeople();

            if(!string.IsNullOrWhiteSpace(sex))
            {
                people = people.Where(p => p.Sex == sex);
            }

            return Ok(people);//TODO: Нужно вернуть только id, name и sex, а age не выводить
        }
        [HttpGet("GetPersonById/{id}")]
        public ActionResult<Person> GetPersonById(string id)
        {
            var person = _peopleRepository.GetPersonById(id);

            return Ok(person);
        }
    }
}
