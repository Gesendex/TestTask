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
        
        [HttpGet("GetPeople")]
        public ActionResult<IEnumerable<Person>> GetPeople(string sex, int x = -1, int y = -1, int start = 0, int count = 50)
        {
            

            return Ok();//TODO: Нужно вернуть только id, name и sex, а age не выводить
        }
        [HttpGet("GetPersonById/{id}")]
        public ActionResult<Person> GetPersonById(string id)
        {
            return Ok();
        }
    }
}
