using CheckManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.DataAccess;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class DtoConverter
    {
        #region Worker
        public static WorkerDto Convert(Worker worker)
        {
            if (worker == null)
                return null;
            WorkerDto workerDto = new WorkerDto();
            workerDto.idWorker = worker.idWorker;
            workerDto.idDivision = worker.idDivision;
            workerDto.Name = worker.Name;
            return workerDto;
        }
        public static Worker Convert(WorkerDto workerDto)
        {
            if (workerDto == null)
                return null;
            Worker worker = new Worker();
            worker.idWorker = workerDto.idWorker;
            worker.idDivision = workerDto.idDivision;
            worker.Name = workerDto.Name;
            return worker;
        }
        public static IList<WorkerDto> Convert(IList<Worker> workers)
        {
            if (workers == null)
                return null;
            IList<WorkerDto> workerDtos = new List<WorkerDto>();
            foreach (var worker in workers)
            {
                workerDtos.Add(Convert(worker));
            }
            return workerDtos;
        }
        #endregion

        #region Division
        public static DivisionDto Convert(Division division)
        {
            if (division == null)
                return null;
            DivisionDto divisiontDto = new DivisionDto();
            divisiontDto.idDivision = division.idDivision;
            divisiontDto.Budget = division.Budget;
            divisiontDto.CountWorkers = division.CountWorkers;
            divisiontDto.Title = division.Title;
            return divisiontDto;
        }
        public static Division Convert(DivisionDto divisionDto)
        {
            if (divisionDto == null)
                return null;
            Division division = new Division();
            division.Budget = divisionDto.Budget;
            division.CountWorkers = divisionDto.CountWorkers;
            division.idDivision = divisionDto.idDivision;
            division.Title = divisionDto.Title;
            return division;
        }
        public static IList<DivisionDto> Convert(IList<Division> divisions)
        {
            if (divisions == null)
                return null;
            IList<DivisionDto> divisionDtos = new List<DivisionDto>();
            foreach (var division in divisions)
            {
                divisionDtos.Add(Convert(division));
            }
            return divisionDtos;
        }

        #endregion

        #region Expense
        public static ExpenseDto Convert(ExpenseByWorker expenseByWorker)
        {
            if (expenseByWorker == null)
                return null;
            ExpenseDto expenseDto = new ExpenseDto();
            expenseDto.Date = expenseByWorker.Date;
            expenseDto.Description = expenseByWorker.Description;
            expenseDto.idConsumption = expenseByWorker.idConsumption;
            expenseDto.idType = expenseByWorker.idType;
            expenseDto.idWorker = expenseByWorker.idWorker;
            expenseDto.Sum = expenseByWorker.Sum;
            return expenseDto;
        }
        public static ExpenseByWorker Convert(ExpenseDto expenseDto)
        {
            if (expenseDto == null)
                return null;
            ExpenseByWorker expenseByWorker = new ExpenseByWorker();
            expenseByWorker.Description = expenseDto.Description;
            expenseByWorker.Date = expenseDto.Date;
            expenseByWorker.idConsumption = expenseDto.idConsumption;
            expenseByWorker.idType = expenseDto.idType;
            expenseByWorker.idWorker = expenseDto.idWorker;
            expenseByWorker.Sum = expenseDto.Sum;
            return expenseByWorker;
        }
        public static IList<ExpenseDto> Convert(IList<ExpenseByWorker> expenseByWorkers)
        {
            if (expenseByWorkers == null)
                return null;
            IList<ExpenseDto> expenseDtos = new List<ExpenseDto>();
            foreach (var expense in expenseByWorkers)
            {
                expenseDtos.Add(Convert(expense));
            }
            return expenseDtos;
        }
        #endregion

        #region TypeExpense
        public static TypeExpenseDto Convert(TypeExpense typeExpense)
        {
            if (typeExpense == null)
                return null;
            TypeExpenseDto typeExpenseDto = new TypeExpenseDto();
            typeExpenseDto.Description = typeExpense.Description;
            typeExpenseDto.idType = typeExpense.idType;
            typeExpenseDto.Limited = typeExpense.Limited;
            typeExpenseDto.Title = typeExpense.Title;

            return typeExpenseDto;
        }
        public static TypeExpense Convert(TypeExpenseDto typeExpenseDto)
        {
            if (typeExpenseDto == null)
                return null;
            TypeExpense typeExpense = new TypeExpense();
            typeExpense.Description = typeExpenseDto.Description;
            typeExpense.idType = typeExpenseDto.idType;
            typeExpense.Limited = typeExpenseDto.Limited;
            typeExpense.Title = typeExpenseDto.Title;
            return typeExpense;
        }
        public static IList<TypeExpenseDto> Convert(IList<TypeExpense> typeExpenses)
        {
            if (typeExpenses == null)
                return null;
            IList<TypeExpenseDto> typeExpenseDtos = new List<TypeExpenseDto>();
            foreach (var typeExpense in typeExpenses)
            {
                typeExpenseDtos.Add(Convert(typeExpense));
            }
            return typeExpenseDtos;
        }
        #endregion
    }

}

