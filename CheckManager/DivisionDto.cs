using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CheckManager
{
    /// <summary>
    /// Хранит информацию об отделе.
    /// </summary>
    public class DivisionDto
    {
        /// <summary>
        /// Номер отдела.
        /// </summary>
        public int idDivision { get; set; }
        /// <summary>
        /// Название отдела.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Количество сотрудников.
        /// </summary>
        public int CountWorkers { get; set; }
        /// <summary>
        /// Бюджет.
        /// </summary>
        public double Budget {  get; set; }
    }
}