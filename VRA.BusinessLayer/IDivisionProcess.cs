using CheckManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.BusinessLayer
{
    public interface IDivisionProcess
    {
        IList<DivisionDto> GetList();

        DivisionDto Get(int id);

        void Add(DivisionDto division);

        void Update(DivisionDto division);

        void Delete(int id);
        IList<DivisionDto> SearchDivision(string title);
    }
}
