using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание действий с таблицей расходов.
    /// </summary>
    public interface IExpenseByWorkerDao
    {
        /// <summary>
        /// Получить отдел по его номеру.
        /// </summary>
        /// <param name="id">Номер отдела.</param>
        /// <returns></returns>
        ExpenseByWorker Get(int id);
        /// <summary>
        /// Получить список всех отделов в базе.
        /// </summary>
        /// <returns>Список всех отделов в базе.</returns>
        IList<ExpenseByWorker> GetAll();
        /// <summary>
        /// Добавить отдел в базу.
        /// </summary>
        /// <param name="expense">Новый отдел.</param
        void Add(ExpenseByWorker expense);
        /// <summary>
        /// Обновить отдел.
        /// </summary>
        /// <param name="expense">Обновленный отдел.</param>
        void Update(ExpenseByWorker expense);
        /// <summary>
        /// Удалить отдел по его номеру.
        /// </summary>
        /// <param name="id">Номер отдела.</param>
        void Delete(int id);
        IList<ExpenseByWorker> SearchExpensebyWorker(int idConsumption, int idWorker, int idType, DateTime date);
    }
}
