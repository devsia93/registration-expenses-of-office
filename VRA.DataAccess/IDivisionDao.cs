using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    /// <summary>
    /// Описание действий с объектом отдела в базе.
    /// </summary>
   public interface IDivisionDao
    {
        /// <summary>
        /// Получить отдел по его номеру.
        /// </summary>
        /// <param name="id">Номер отдела.</param>
        /// <returns></returns>
         Division Get(int id);
        /// <summary>
        /// Получить список всех отделов в базе.
        /// </summary>
        /// <returns>Список всех отделов в базе.</returns>
        IList<Division> GetAll();
        /// <summary>
        /// Добавить отдел в базу.
        /// </summary>
        /// <param name="division">Новый отдел.</param
         void Add(Division division);
        /// <summary>
        /// Обновить отдел.
        /// </summary>
        /// <param name="division">Обновленный отдел.</param>
         void Update(Division division);
        /// <summary>
        /// Удалить отдел по его номеру.
        /// </summary>
        /// <param name="id">Номер отдела.</param>
         void Delete(int id);

        IList<Division> SearchDivision(string title);
    }
}
