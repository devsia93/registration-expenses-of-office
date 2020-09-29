using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;
using CheckManager;

namespace VRA.BusinessLayer
{
    class TypeExpenseProcessDb:ITypeExpenseProcess
    {
        private readonly ITypeExpenseDao _typeExpenseDao;
        public TypeExpenseProcessDb()
        {
            _typeExpenseDao = DaoFactory.GetTypeExpense();
        }
        public void Add(TypeExpenseDto expenseDto)
        {
            _typeExpenseDao.Add(DtoConverter.Convert(expenseDto));
        }

        public void Delete(int id)
        {
            _typeExpenseDao.Delete(id);
        }

        public TypeExpenseDto Get(int id)
        {
            return DtoConverter.Convert(_typeExpenseDao.Get(id));
        }

        public IList<TypeExpenseDto> GetList()
        {
            return DtoConverter.Convert(_typeExpenseDao.GetAll());
        }

        public void Update(TypeExpenseDto expenseDto)
        {
            _typeExpenseDao.Update(DtoConverter.Convert(expenseDto));
        }
        public IList<TypeExpenseDto> SearchTypeExpense(int id, string titleExpense)
        {
            return DtoConverter.Convert(_typeExpenseDao.SearchTypeExpense(id, titleExpense));
        }
        public List<int> GetTypeID()
        {
            return _typeExpenseDao.GetTypeID();
        }
    }
}
