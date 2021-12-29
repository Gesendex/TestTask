using System;
using System.Collections.Generic;
using TestTask.Models;

namespace TestTask.Interfaces
{
    public interface IPeopleRepository
    {
        public IEnumerable<Person> GetPeople();
        public Person GetPersonById(string id);
        public IEnumerable<Person> GetPeopleBySex(string sex);
        public IEnumerable<Person> GetPeopleByAge(int? min, int? max);
    }
}
