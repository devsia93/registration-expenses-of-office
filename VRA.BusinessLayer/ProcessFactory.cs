using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.DataAccess;


namespace VRA.BusinessLayer
{
    public class ProcessFactory
    {
        public static ISettingsProcess GetSettingsProcess()
        {
            return new SettingsProcess();
        }
        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IWorkerProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IWorkerProcess GetWorkerProcess()
        {
            return new WorkerProcessDb();
        }

        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IDivisionProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IDivisionProcess GetDivisionProcess()
        {
            return new DivisionProcessDb();
        }
        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IExpenseByWorkerProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IExpenseByWorkerProcess GetExpenseByWorkerProcess()
        {
            return new ExpenseByWorkerProcessDb();
        }
        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IExpenseByWorkerProcess"/>
        /// </summary>
        /// <returns></returns>
        public static ITypeExpenseProcess GetTypeExpenseProcess()
        {
            return new TypeExpenseProcessDb();
        }
        public static IReportGenerator GetReport()
        {
            return new ReportGenerator();
        }

    }
}
