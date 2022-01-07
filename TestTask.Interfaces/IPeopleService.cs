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
        /// <summary>
        /// Метод возращает коллекцию людей по заданным параметрам
        /// </summary>
        /// <param name="sex">Пол "male" или "female"</param>
        /// <param name="x">Нижняя граница возраста</param>
        /// <param name="y">Верхняя граница возраста</param>
        /// <param name="pageSize">Размер возращаемой страницы данных</param>
        /// <param name="pageNumber">Номер возращаемой страницы данных</param>
        /// <returns>Коллекция людей</returns>
        public IQueryable<Person> GetPeople(string sex, int x, int y, int pageSize, int pageNumber);
        /// <summary>
        /// Метод возращает человека по заданному Id
        /// </summary>
        /// <param name="id">Id человека которого нужно вернуть</param>
        /// <returns>Человек с заданным Id</returns>
        public Person GetPerson(string id);
    }
}
