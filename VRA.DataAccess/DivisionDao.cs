using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    public class DivisionDao : BaseDao, IDivisionDao
    {
        private static Division LoadDivision (SqlDataReader reader)
        {
            //Создаём пустой объект
            Division division = new Division();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            division.idDivision = reader.GetInt32(reader.GetOrdinal("idDivision"));
            division.Title = reader.GetString(reader.GetOrdinal("title"));
            division.Budget = reader.GetDouble(reader.GetOrdinal("budget"));
            division.CountWorkers = reader.GetInt32(reader.GetOrdinal("countWorkers"));
            return division;
        }
        public void Add(Division division)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Division (title, countWorkers, budget)" +
                        "VALUES (@title, @count, @budget)";
                    //cmd.Parameters.AddWithValue("@id", division.idDivision);
                    cmd.Parameters.AddWithValue("@title", division.Title);
                    cmd.Parameters.AddWithValue("@count", division.CountWorkers);
                    cmd.Parameters.AddWithValue("@budget", division.Budget);
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
                    cmd.CommandText = "DELETE FROM Division WHERE idDivision = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Division Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idDivision, title, countWorkers, budget FROM Division WHERE idDivision = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadDivision(dataReader);
                    }
                }
            }
        }

        public IList<Division> GetAll()
        {
            IList<Division> divisions = new List<Division>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idDivision, title, countWorkers, budget FROM Division";
                        using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            divisions.Add(LoadDivision(dataReader));
                        }
                    }
                }

            }
            return divisions;
        }

        public void Update(Division division)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Division SET title = @title," +
                        " countWorkers = @countWorkers, budget = @budget " +
                        "WHERE idDivision = @id";
                    cmd.Parameters.AddWithValue("@id", division.idDivision);
                    cmd.Parameters.AddWithValue("@title", division.Title);
                    cmd.Parameters.AddWithValue("@countWorkers", division.CountWorkers);
                    cmd.Parameters.AddWithValue("@budget", division.Budget);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        IList<Division> IDivisionDao.SearchDivision(string title)
        {
            IList<Division> divisions = new List<Division>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idDivision, title, countWorkers, budget FROM Division WHERE title = @title";
                    cmd.Parameters.AddWithValue("@title", title);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            divisions.Add(LoadDivision(dataReader));
                        }
                    }
                }
            }
            return divisions;
        }
    }
}
