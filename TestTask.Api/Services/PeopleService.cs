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
        /// <summary>
        /// Метод возращает коллекцию людей по заданным параметрам
        /// </summary>
        /// <param name="sex">Пол "male" или "female"</param>
        /// <param name="x">Нижняя граница возраста, не включительно. Если верхняя граница <= 0 тогда данный фильтр не применяется</param>
        /// <param name="y">Верхняя граница возраста, не включительно. Если верхняя граница <= 0 тогда данный фильтр не применяется</param>
        /// <param name="pageSize">Размер возращаемой страницы данных</param>
        /// <param name="pageNumber">Номер возращаемоq страницы данных</param>
        /// <returns>Коллекция людей</returns>
        public IQueryable<Person> GetPeople(string sex = null, int x = 0, int y = 0, int pageNumber = 1 , int pageSize = 50)
        {
            var people = _repository.GetPeople();
            if(sex is not null)
            {
                people = people.Where(p => p.Sex == sex);
            }

            if(y > 0)
            {
                people = people.Where(p => p.Age < y && p.Age > x);
            }

            return people.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        /// <summary>
        /// Метод возращает человека по заданному Id
        /// </summary>
        /// <param name="id">Id человека которого нужно вернуть</param>
        /// <returns>Человек с заданным Id. Если пользователь не найден возращает Null</returns>
        public Person GetPerson(string id)
        {
            return _repository.GetPersonById(id);
        }
    }
}
