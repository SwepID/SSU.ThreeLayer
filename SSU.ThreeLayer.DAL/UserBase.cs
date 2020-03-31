using SSU.ThreeLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.DAL
{
    public class UserBase : IUserBase
    {
        string connectionString = "Data Source=DESKTOP-LJEFIBE\\SQLEXPRESS;Initial Catalog = Base; Integrated Security = True";
        public string AddUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddUser";
                    command.Parameters.Add("userName", SqlDbType.NVarChar).Value = user.Name;
                    command.Parameters.Add("dateOfBorn", SqlDbType.Date).Value = user.DateOfBirth;
                    command.Parameters.Add("age", SqlDbType.Int).Value = user.Age;
                    var rowCount = command.ExecuteNonQuery();
                    return "Пользователь успешно добавлен. Строк добавлено = " + rowCount;
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
            }
        }

        public string DeleteUser(int idUser)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteUser";
                    command.Parameters.Add("idUser", SqlDbType.Int).Value = idUser;
                    if (command.ExecuteNonQuery() >= 1)
                    {
                        return "Пользователь с ID " + idUser + " успешно удален!";
                    }
                    else
                    {
                        return "Не удалось удалить пользователя с ID " + idUser + "!";
                    }
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
            }
        }

        public IEnumerable<User> FindUser(string name)
        {
            List<User> listUsers = new List<User>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FindUser";
                command.Parameters.Add("userName", SqlDbType.NVarChar).Value = name;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listUsers.Add(new User((int)dataReader["idUser"], (string)dataReader["userName"], (DateTime)dataReader["dateOfBorn"], (int)dataReader["age"]));
                    }
                }
            }
            return listUsers;
        }

        public IEnumerable<User> ShowAllUsers()
        {
            List<User> listUsers = new List<User>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllUsers";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listUsers.Add(new User((int)dataReader["idUser"], (string)dataReader["userName"], (DateTime)dataReader["dateOfBorn"], (int)dataReader["age"]));
                    }
                }
            }
            return listUsers;
        }

        public IEnumerable<User> SortByName()
        {
            List<User> listUsers = new List<User>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SortByName";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listUsers.Add(new User((int)dataReader["idUser"], (string)dataReader["userName"], (DateTime)dataReader["dateOfBorn"], (int)dataReader["age"]));
                    }
                }
            }
            return listUsers;
        }
    }
}
