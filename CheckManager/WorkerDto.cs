using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Содержит описание переменных для таблицы Работник.
    /// </summary>
    public class WorkerDto
    {
        /// <summary>
        /// ID отдела.
        /// </summary>
        public int idDivision { get; set; }
        /// <summary>
        /// Имя работника.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Number of worker.
        /// </summary>
        public int idWorker { get; set; }
    }
}
