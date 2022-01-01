using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Interfaces
{
    interface IPeopleService
    {
        public IQueryable<Person> GetPeople(string sex = null, int x = -1, int y = -1, int count = 50, int start = 0);
        public Person GetPerson(string id);
    }
}
