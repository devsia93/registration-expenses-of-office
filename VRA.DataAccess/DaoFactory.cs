using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    public class DaoFactory
    {
        public static IDivisionDao GetDivision()
        {
            return new DivisionDao();
        }
        public static IExpenseByWorkerDao GetExpenseByWorker()
        {
            return new ExpenseByWorkerDao();
        }
        public static ITypeExpenseDao GetTypeExpense()
        {
            return new TypeExpenseDao();
        }
        public static IWorkerDao GetWorker()
        {
            return new WorkerDao();
        }
    }
}
