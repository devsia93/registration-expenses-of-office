using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    /// <summary>
    /// Описание действий с объектом работника в базе
    /// </summary>
    public interface IWorkerDao
    {
        /// <summary>
        /// Получить работника по его номеру.
        /// </summary>
        /// <param name="id">Номер работника.</param>
        /// <returns></returns>
        Worker Get(int id);
        /// <summary>
        /// Получить список всех работников в базе.
        /// </summary>
        /// <returns>Список всех работников в базе.</returns>
        IList<Worker> GetAll();
        /// <summary>
        /// Добавить работника в базу.
        /// </summary>
        /// <param name="worker">Новый работник.</param
        void Add(Worker worker);
        /// <summary>
        /// Обновить работника.
        /// </summary>
        /// <param name="worker">Обновленный работник.</param>
        void Update(Worker worker);
        /// <summary>
        /// Удалить работника по его номеру.
        /// </summary>
        /// <param name="id">Номер работника.</param>
        void Delete(int id);
        /// <summary>
        /// Поиск работника по его номеру или имени.
        /// </summary>
        /// <param name="id">Номер работника.</param>
        /// <param name="name">Имя работника.</param>
        /// <returns>Список работников.</returns>
        IList<Worker> SearchWorker(string name);
    }
}
