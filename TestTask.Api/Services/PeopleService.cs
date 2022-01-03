using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Api.Queries;
using TestTask.Interfaces;
using TestTask.Models;

namespace TestTask.Api.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;
        public PeopleService(IPeopleRepository repository)
        {
            _repository = repository;
        }
        public IQueryable<Person> GetPeople(string sex = null, int x = 0, int y = 0, int pageNumber = 1 , int pageSize = 50)
        {
            var people = _repository.GetPeople();
            if(sex is not null)
            {
                people = people.Where(p => p.Sex == sex);
            }

            if(y > x)
            {
                people = people.Where(p => p.Age < y && p.Age > x);
            }

            return people.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public Person GetPerson(string id)
        {
            return _repository.GetPersonById(id);
        }
    }
}
