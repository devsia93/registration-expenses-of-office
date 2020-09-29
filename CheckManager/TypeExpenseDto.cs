using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckManager
{
    /// <summary>
    /// Содержит информацию о типе расходов.
    /// </summary>
    public class TypeExpenseDto
    {
        /// <summary>
        /// Номер типа расходов.
        /// </summary>
        public int idType { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Установленный лимит на данный тип.
        /// </summary>
        public double Limited { get; set; }
    }
}
