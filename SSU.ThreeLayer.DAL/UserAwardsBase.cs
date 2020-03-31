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
    public class UserAwardsBase : IUserAwardsBase
    {
        string connectionString = "Data Source=DESKTOP-LJEFIBE\\SQLEXPRESS;Initial Catalog = Base; Integrated Security = True";
        public string AddAwardForUser(int idAward, int idUser)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddAwardForUser";
                    command.Parameters.Add("idUser", SqlDbType.Int).Value = idUser;
                    command.Parameters.Add("idAward", SqlDbType.Int).Value = idAward;
                    var rowCount = command.ExecuteNonQuery();
                    return $"Награда для пользователя успешно добавлена. Строк добавлено = {rowCount}";
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
            }
        }

        public string DeleteAwardForUser(int idAward, int idUser)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteUserAwards";
                    command.Parameters.Add("idAward", SqlDbType.Int).Value = idAward;
                    command.Parameters.Add("idUser", SqlDbType.Int).Value = idUser;
                    if (command.ExecuteNonQuery() >= 1)
                    {
                        return $"Награда с ID {idAward} для пользователя с ID {idUser} успешно удалена!";
                    }
                    else
                    {
                        return $"Не удалось удалить награду с ID {idAward} для пользователя с ID {idUser}!";
                    }
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
            }
        }

        public IEnumerable<Award> GetAwardsForUser(int idUser)
        {
            List<Award> listAwards = new List<Award>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAwardsForUser";
                command.Parameters.Add("idUser", SqlDbType.Int).Value = idUser;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listAwards.Add(new Award((int)dataReader["idAward"], (string)dataReader["title"]));
                    }
                }
            }
            return listAwards;
        }

        public IEnumerable<User> GetUsersForAward(int idAward)
        {
            List<User> listUsers = new List<User>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUsersForAward";
                command.Parameters.Add("idAward", SqlDbType.Int).Value = idAward;
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
