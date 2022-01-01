using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Models;

namespace TestTask.Interfaces
{
    public interface IPeopleRepository
    {
        public IQueryable<Person> GetPeople();
        public Person GetPersonById(string id);
        public IQueryable<Person> GetPeopleBySex(string sex);
        public IQueryable<Person> GetPeopleByAge(int min, int max);
    }
}
