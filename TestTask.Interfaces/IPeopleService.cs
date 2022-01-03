using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Interfaces
{
    public interface IPeopleService
    {
        public IQueryable<Person> GetPeople(string sex, int x, int y, int pageSize, int pageNumber);
        public Person GetPerson(string id);
    }
}
