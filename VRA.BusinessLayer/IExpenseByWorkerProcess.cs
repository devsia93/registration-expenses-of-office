using CheckManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IExpenseByWorkerProcess
    {
        IList<ExpenseDto> GetList();

        ExpenseDto Get(int id);

        void Add(ExpenseDto expense);

        void Update(ExpenseDto expense);

        void Delete(int id);
        IList<ExpenseDto> SearchExpenseByWorker(int idConsumption, int idWorker, int idType, DateTime date);
    }
}
