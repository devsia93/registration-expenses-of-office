using CheckManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    class DivisionProcessDb:IDivisionProcess
    {
        private readonly IDivisionDao _divisionDao;
        public DivisionProcessDb()
        {
            _divisionDao = DaoFactory.GetDivision();
        }
        public void Add(DivisionDto divisionDto)
        {
            _divisionDao.Add(DtoConverter.Convert(divisionDto));
        }

        public void Delete(int id)
        {
            _divisionDao.Delete(id);
        }

        public DivisionDto Get(int id)
        {
            return DtoConverter.Convert(_divisionDao.Get(id));
        }

        public IList<DivisionDto> GetList()
        {
            return DtoConverter.Convert(_divisionDao.GetAll());
        }

        public void Update(DivisionDto divisionDto)
        {
            _divisionDao.Update(DtoConverter.Convert(divisionDto));
        }

        public IList<DivisionDto> SearchDivision(string title)
        {
            return DtoConverter.Convert(_divisionDao.SearchDivision(title));
        }
    }
}
