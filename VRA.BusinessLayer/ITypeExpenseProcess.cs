using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckManager;

namespace VRA.BusinessLayer
{
    public interface ITypeExpenseProcess
    {
        IList<TypeExpenseDto> GetList();

        TypeExpenseDto Get(int id);

        void Add(TypeExpenseDto type);

        void Update(TypeExpenseDto type);

        void Delete(int id);
        IList<TypeExpenseDto> SearchTypeExpense(int id, string titleExpense);
        List<int> GetTypeID();
    }
}
