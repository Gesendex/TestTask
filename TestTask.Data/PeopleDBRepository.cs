using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using TestTask.Interfaces;
using TestTask.Models;

namespace TestTask.Data
{
    public class PeopleDBRepository : IPeopleRepository
    {
        private TestTaskDBContext _db;
        public PeopleDBRepository(TestTaskDBContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Метод возвращает всех людей
        /// </summary>
        /// <returns>Возвращает коллекцию людей </returns>
        public IQueryable<Person> GetPeople()
        {
            return _db.People;
        }
        /// <summary>
        /// Метод возвращает людей в указаном возрастном промежутке
        /// </summary>
        /// <param name="min">Нижняя граница возраста, передайте null если не хотите делать выборку по нижней границе</param>
        /// <param name="max">Верхняя граница возраста, передайте null если не хотите делать выборку по верхней границе</param>
        /// <returns>Коллекция люде в заданом возрастном промежутке</returns>
        public IQueryable<Person> GetPeopleByAge(int min, int max)
        {
            return _db.People.Where(p => p.Age >= min && p.Age <= max);
        }
        /// <summary>
        /// Метод возвращает людей указанного пола полу
        /// </summary>
        /// <param name="sex">Пол человека</param>
        /// <returns>Коллекция людей указанного пола</returns>
        public IQueryable<Person> GetPeopleBySex(string sex)
        {
            return _db.People.Where(p => p.Sex == sex);
        }
        /// <summary>
        /// Метод возвращает человека с заданным id
        /// </summary>
        /// <param name="id">id человека</param>
        /// <returns>Возвращает человека с заданным id</returns>
        public Person GetPersonById(string id)
        {
            return _db.People.FirstOrDefault(p => p.Id == id);
        }
    }
}
