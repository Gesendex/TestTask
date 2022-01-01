using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestTask.Interfaces;
using TestTask.Models;

namespace TestTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        [HttpGet("GetPeople")]
        public ActionResult<IEnumerable<Person>> GetPeople(string sex, int x, int y, int start, int count = 50)
        {
            var result = _peopleService.GetPeople(sex, x, y, count, start).AsEnumerable();
            return Ok(result);//TODO: Нужно вернуть только id, name и sex, а age не выводить
        }

        [HttpGet("GetPerson/{id}")]
        public ActionResult<Person> GetPerson(string id)
        {
            var result = _peopleService.GetPerson(id);
            return result;
        }
    }
}
