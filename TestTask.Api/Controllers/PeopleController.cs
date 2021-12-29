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
        [HttpGet("GetPeople/{sex?}")]
        public ActionResult<IEnumerable<Person>> GetPeople(string sex)
        {
            var people = _peopleRepository.GetPeople();

            if(!string.IsNullOrWhiteSpace(sex))
            {
                people = people.Where(p => p.Sex == sex);
            }

            return Ok(people);//TODO: Нужно вернуть только id, name и sex, а age не выводить
        }
    }
}
