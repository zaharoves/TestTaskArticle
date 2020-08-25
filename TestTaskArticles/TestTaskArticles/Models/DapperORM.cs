using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TestTaskArticles.Models
{
    /// <summary>
    /// Класс для запросов к БД
    /// </summary>
    public static class DapperORM
    {
        private static string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=ArticlesDB;Integrated Security=True";

        /// <summary>
        /// Выполняет запрос в базу данных на выполнение хранимой процедуры
        /// </summary>
        /// <param name="procedureName">Название ранимой процедуры</param>
        /// <param name="param">Входные параметры для хранимой процедуры</param>
        public static void Execute(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Выполняет запрос в базу данных на выполнение хранимой процедуры
        /// </summary>
        /// <typeparam name="T">Тип модели</typeparam>
        /// <param name="procedureName">Название ранимой процедуры</param>
        /// <param name="param">Входные параметры для хранимой процедуры</param>
        /// <returns>Коллекцию моделей</returns>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                return sqlConnection.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
