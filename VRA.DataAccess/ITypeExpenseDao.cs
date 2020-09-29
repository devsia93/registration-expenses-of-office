using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание действий с таблицей типов расходов.
    /// </summary>
    public interface ITypeExpenseDao
    {
        /// <summary>
        /// Получить тип по его номеру.
        /// </summary>
        /// <param name="id">Номер типа.</param>
        /// <returns></returns>
        TypeExpense Get(int id);
        /// <summary>
        /// Получить список всех типов в базе.
        /// </summary>
        /// <returns>Список всех типов в базе.</returns>
        IList<TypeExpense> GetAll();
        /// <summary>
        /// Добавить тип в базу.
        /// </summary>
        /// <param name="typeExpense">Новый тип.</param
        void Add(TypeExpense typeExpense);
        /// <summary>
        /// Обновить тип.
        /// </summary>
        /// <param name="typeExpense">Обновленный тип.</param>
        void Update(TypeExpense typeExpense);
        /// <summary>
        /// Удалить тип по его номеру.
        /// </summary>
        /// <param name="id">Номер типа.</param>
        void Delete(int id);
        IList<TypeExpense> SearchTypeExpense(int id, string titleExpense);
        List<int> GetTypeID();
    }
}
