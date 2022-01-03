using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Api.Queries
{
    /// <summary>
    /// Класс описывает настроки страницы.
    /// </summary>
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 50;
        }
        private int _pageNumber;
        public int PageNumber
        {
            get { return _pageNumber; }
            //Валидация номера страницы
            set { _pageNumber = value > 0? value: 1; }
        }

        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            //Валидация размера страницы
            set { _pageSize = value > 50 ? 50 
                    : value > 0 ? value : 1; }
        }

    }
}
