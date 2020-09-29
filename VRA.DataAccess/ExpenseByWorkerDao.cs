using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    class ExpenseByWorkerDao : BaseDao, IExpenseByWorkerDao
    {
        private static ExpenseByWorker LoadExpenseByWorker(SqlDataReader reader)
        {
            //Создаём пустой объект
            ExpenseByWorker expenseByWorker = new ExpenseByWorker();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            expenseByWorker.Date = reader.GetDateTime(reader.GetOrdinal("date"));
            expenseByWorker.Description = reader.GetString(reader.GetOrdinal("description"));
            expenseByWorker.idConsumption = reader.GetInt32(reader.GetOrdinal("idConsumption"));
            expenseByWorker.idType = reader.GetInt32(reader.GetOrdinal("idType"));
            expenseByWorker.idWorker = reader.GetInt32(reader.GetOrdinal("idWorker"));
            expenseByWorker.Sum = reader.GetDouble(reader.GetOrdinal("sum"));
            return expenseByWorker;
        }
        public void Add(ExpenseByWorker expense)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ExpenseByWorker (date, description, idType, idWorker, sum)" +
                        "VALUES (@date, @description, @idType, @idWorker, @sum)";
                    cmd.Parameters.AddWithValue("@date", expense.Date);
                    cmd.Parameters.AddWithValue("@description", expense.Description);
                    //cmd.Parameters.AddWithValue("@idConsumption", expense.idConsumption);
                    cmd.Parameters.AddWithValue("@idType", expense.idType);
                    cmd.Parameters.AddWithValue("@idWorker", expense.idWorker);
                    cmd.Parameters.AddWithValue("@sum", expense.Sum);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ExpenseByWorker WHERE idConsumption = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ExpenseByWorker Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT date, description, idConsumption, idType, idWorker, sum FROM ExpenseByWorker WHERE idConsumption = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadExpenseByWorker(dataReader);
                    }
                }
            }
        }

        public IList<ExpenseByWorker> GetAll()
        {
            IList<ExpenseByWorker> expenseByWorkers = new List<ExpenseByWorker>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT date, description, idConsumption, idType, idWorker, sum FROM ExpenseByWorker";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            expenseByWorkers.Add(LoadExpenseByWorker(dataReader));
                        }
                    }
                }

            }
            return expenseByWorkers;
        }
        public void Update(ExpenseByWorker expense)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE ExpenseByWorkers SET date = @date, description = @description, " +
                        "idType = @idType, idWorker = @idWorker, sum = @sum " +
                        "WHERE idConsumption = @idConsumption";
                    cmd.Parameters.AddWithValue("@idConsumption", expense.idConsumption);
                    cmd.Parameters.AddWithValue("@date", expense.Date);
                    cmd.Parameters.AddWithValue("@description", expense.Description);
                    cmd.Parameters.AddWithValue("@idType", expense.idType);
                    cmd.Parameters.AddWithValue("@idWorker", expense.idWorker);
                    cmd.Parameters.AddWithValue("@sum", expense.Sum);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        IList<ExpenseByWorker> IExpenseByWorkerDao.SearchExpensebyWorker(int idConsumption, int idWorker, int idType, DateTime date)
        {
            IList<ExpenseByWorker> expenseByWorkers = new List<ExpenseByWorker>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idConsumption, idWorker, idType, date FROM ExpenseByWorker WHERE idConsumption LIKE @idConsumption AND idWorker LIKE @idWorker AND idType LIKE @idType AND date LIKE @date";
                    cmd.Parameters.AddWithValue("@idConsumption", "%" + idConsumption + "%");
                    cmd.Parameters.AddWithValue("@idWorker", "%" + idWorker + "%");
                    cmd.Parameters.AddWithValue("@idType", "%" + idType + "%");
                    cmd.Parameters.AddWithValue("@date", "%" + date + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            expenseByWorkers.Add(LoadExpenseByWorker(dataReader));
                        }
                    }
                }
            }
            return expenseByWorkers;
        }
    }
}
