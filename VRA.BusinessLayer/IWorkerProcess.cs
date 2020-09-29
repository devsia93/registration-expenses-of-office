using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IWorkerProcess
    {
        IList<WorkerDto> GetList();

        WorkerDto Get(int id);

        void Add(WorkerDto worker);

        void Update(WorkerDto worker);

        void Delete(int id);

        IList<WorkerDto> SearchWorker(string name);
    }
}
