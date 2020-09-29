using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;
using CheckManager;

namespace VRA.BusinessLayer
{
    public class ExpenseByWorkerProcessDb:IExpenseByWorkerProcess
    {
        private readonly  IExpenseByWorkerDao _expenseByWorkerDao;
        public ExpenseByWorkerProcessDb()
        {
            _expenseByWorkerDao = DaoFactory.GetExpenseByWorker();
        }
        public void Add(ExpenseDto expenseDto)
        {
            _expenseByWorkerDao.Add(DtoConverter.Convert(expenseDto));
        }

        public void Delete(int id)
        {
            _expenseByWorkerDao.Delete(id);
        }

        public ExpenseDto Get(int id)
        {
            return DtoConverter.Convert(_expenseByWorkerDao.Get(id));
        }

        public IList<ExpenseDto> GetList()
        {
            return DtoConverter.Convert(_expenseByWorkerDao.GetAll());
        }

        public void Update(ExpenseDto expenseDto)
        {
            _expenseByWorkerDao.Update(DtoConverter.Convert(expenseDto));
        }
        public IList<ExpenseDto> SearchExpenseByWorker(int idConsumption, int idWorker, int idType, DateTime date)
        {
            return DtoConverter.Convert(_expenseByWorkerDao.SearchExpensebyWorker(idConsumption, idWorker, idType, date));
        }
    }
}
