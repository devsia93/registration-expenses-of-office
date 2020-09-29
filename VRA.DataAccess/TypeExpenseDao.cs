using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    class TypeExpenseDao : BaseDao, ITypeExpenseDao
    {
        private static TypeExpense LoadTypeExpense(SqlDataReader reader)
        {
            //Создаём пустой объект
            TypeExpense typeExpense = new TypeExpense();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            typeExpense.Description = reader.GetString(reader.GetOrdinal("descriptionExpense"));
            typeExpense.idType = reader.GetInt32(reader.GetOrdinal("idType"));
            typeExpense.Limited = reader.GetDouble(reader.GetOrdinal("limitedExpense"));
            typeExpense.Title = reader.GetString(reader.GetOrdinal("titleExpense"));
            return typeExpense;
        }
        public void Add(TypeExpense typeExpense)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                 "INSERT INTO TypeExpense(descriptionExpense, limitedExpense, titleExpense) " +
                 "VALUES( @descriptionExpense, @limitedExpense, @titleExpense)";
                    cmd.Parameters.AddWithValue("@descriptionExpense", typeExpense.Description);
                    cmd.Parameters.AddWithValue("@limitedExpense", typeExpense.Limited);
                    cmd.Parameters.AddWithValue("@titleExpense", typeExpense.Title);
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
                    cmd.CommandText = "DELETE FROM TypeExpense WHERE idType = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TypeExpense Get(int id)
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
                    cmd.CommandText = "SELECT idType, descriptionExpense, limitedExpense, titleExpense " +
                        "FROM TypeExpense WHERE idType = @id";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    //Открываем SqlDataReader для чтения полученных в результате
                    // выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadTypeExpense(dataReader);
                    }
                }
            }
        }

        public IList<TypeExpense> GetAll()
        {
            IList<TypeExpense> typeExpenses = new List<TypeExpense>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idType, descriptionExpense, limitedExpense, titleExpense FROM TypeExpense";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            typeExpenses.Add(LoadTypeExpense(dataReader));
                        }
                    }
                }
            }
            return typeExpenses;
        }

        public void Update(TypeExpense typeExpense)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE TypeExpense SET descriptionExpense = @descriptionExpense, " +
                        "limitedExpense = @limitedExpense, titleExpense = @titleExpense WHERE idType = @idType";
                    cmd.Parameters.AddWithValue("@idType", typeExpense.idType);
                    cmd.Parameters.AddWithValue("@descriptionExpense", typeExpense.Description);
                    cmd.Parameters.AddWithValue("@limitedExpense", typeExpense.Limited);
                    cmd.Parameters.AddWithValue("@titleExpense", typeExpense.Title);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<int> GetTypeID()
        {
            IList<TypeExpense> typeExpenses = GetAll();
            List<int> result = new List<int>();
            foreach (TypeExpense type in typeExpenses)
                result.Add(type.idType);
            return result;

        }

        IList<TypeExpense> ITypeExpenseDao.SearchTypeExpense(int id, string titleExpense)
        {
            IList<TypeExpense> typeExpenses = new List<TypeExpense>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idType, titleExpense, descriptionExpense, limitedExpense FROM TypeExpense WHERE idType LIKE @idType AND titleExpense LIKE @titleExpense";
                    cmd.Parameters.AddWithValue("@idType", "%" + id + "%");
                    cmd.Parameters.AddWithValue("@titleExpense", "%" + titleExpense + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            typeExpenses.Add(LoadTypeExpense(dataReader));
                        }
                    }
                }
            }
            return typeExpenses;
        }
    }
}
