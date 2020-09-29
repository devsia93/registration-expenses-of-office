using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    public class WorkerDao : BaseDao, IWorkerDao
    {
        private static Worker LoadWorker(SqlDataReader reader)
        {
            //Создаём пустой объект
            Worker worker = new Worker();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            worker.idWorker = reader.GetInt32(reader.GetOrdinal("idWorker"));
            worker.idDivision = Convert.ToInt32(reader["idDivision"]);
            worker.Name = reader.GetString(reader.GetOrdinal("name"));
            return worker;
        }

        public void Add(Worker worker)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                 "INSERT INTO Worker(idDivision, name) VALUES(@idDivision, @name)";
                    cmd.Parameters.AddWithValue("@name", worker.Name);
                    cmd.Parameters.AddWithValue("@idDivision", worker.idDivision);
                    //cmd.Parameters.AddWithValue("@idWorker", worker.idWorker);
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
                    cmd.CommandText = "DELETE FROM Worker WHERE idWorker = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Worker Get(int id)
        {
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT idWorker, idDivision, name FROM WORKER WHERE idWorker = @id";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    //Открываем SqlDataReader для чтения полученных в результате
                    // выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadWorker(dataReader);
                    }
                }
            }
        }

        public IList<Worker> GetAll()
        {
            IList<Worker> worker = new List<Worker>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idWorker, idDivision, name FROM Worker";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            worker.Add(LoadWorker(dataReader));
                        }
                    }
                }
            }
            return worker;
        }

        public void Update(Worker worker)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Worker SET name = @Name, idWorker = @idWorker WHERE idWorker = @ID";
                    cmd.Parameters.AddWithValue("@Name", worker.Name);
                    cmd.Parameters.AddWithValue("@idDivision", worker.idDivision);
                    cmd.Parameters.AddWithValue("@ID", worker.idWorker);
                    cmd.Parameters.AddWithValue("@idWorker", worker.idWorker);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        IList<Worker> IWorkerDao.SearchWorker(string name)
        {
            IList<Worker> workers = new List<Worker>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idWorker, idDivision, name FROM Worker WHERE name = @name";
                    cmd.Parameters.AddWithValue("@name", name);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            workers.Add(LoadWorker(dataReader));
                        }
                    }
                }
            }
            return workers;
        }
    }
}
