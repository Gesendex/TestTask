using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestTask.Api.Queries;
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
        public IActionResult GetPeople(string sex, int x, int y,[FromQuery] PaginationQuery paginationQuery)
        {
            var result = _peopleService.GetPeople(sex, x, y, paginationQuery.PageNumber, paginationQuery.PageSize)
                .Select(s => new { Id = s.Id, Name = s.Name, Sex = s.Sex })
                .AsEnumerable();
            
            return Ok(result);
        }
        [HttpGet("GetPerson/{id}")]
        public IActionResult GetPerson(string id)
        {
            var result = _peopleService.GetPerson(id);
            return Ok(result);
        }
    }
}
