using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckManager
{
    /// <summary>
    /// Хранит информацию о расходе.
    /// </summary>
    public class ExpenseDto
    {
        /// <summary>
        /// Номер расхода.
        /// </summary>
        public int idConsumption { get; set; }
        /// <summary>
        /// Номер работника, сделавшего расход.
        /// </summary>
        public int idWorker { get; set; }
        /// <summary>
        /// Номер типа расхода.
        /// </summary>
        public int idType { get; set; }
        /// <summary>
        /// Описание расхода.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Сумма расхода.
        /// </summary>
        public double Sum { get; set; }
        /// <summary>
        /// Дата, когда был сделан расход.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
