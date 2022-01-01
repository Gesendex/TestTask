using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Interfaces;
using TestTask.Models;

namespace TestTask.Api.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;
        private const int MAX_COUNT = 50;
        public PeopleService(IPeopleRepository repository)
        {
            _repository = repository;
        }
        public IQueryable<Person> GetPeople(string sex = null, int x = 0, int y = 0, int count = MAX_COUNT, int start = 0)
        {
            var people = _repository.GetPeople();
            if(sex is not null)
            {
                people = people.Where(p => p.Sex == sex);
            }

            if(x > y)
            {
                people = people.Where(p => p.Age < y && p.Age > x);
            }

            if (count > MAX_COUNT) count = MAX_COUNT;
            else if (count < 0) count = 0;

            if (start < 0) start = 0;

            return people.Skip(start).Take(count);
        }

        public Person GetPerson(string id)
        {
            return _repository.GetPersonById(id);
        }
    }
}
