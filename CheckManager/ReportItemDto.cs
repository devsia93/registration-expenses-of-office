using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckManager
{
    public class ReportItemDto
    {
        /// <summary>
        /// Содердит информацию о дате.
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// Содержит информацию о количестве.
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// Содержит информацию о цене.
        /// </summary>
        public double price { get; set; }
    }
}
