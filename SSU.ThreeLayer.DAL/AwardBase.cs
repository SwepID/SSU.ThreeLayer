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
    public class AwardBase : IAwardBase
    {
        string connectionString = "Data Source=DESKTOP-LJEFIBE\\SQLEXPRESS;Initial Catalog = Base; Integrated Security = True";
        public string AddAward(Award award)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddAward";
                    command.Parameters.Add("title", SqlDbType.NVarChar).Value = award.Title;
                    var rowCount = command.ExecuteNonQuery();
                    return "Товар успешно добавлен. Строк добавлено = " + rowCount;
                }
                catch (Exception exception)
                {
                    return exception.StackTrace;
                }
            }
        }

        public string DeleteAward(int idAward)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteAward";
                    command.Parameters.Add("idAward", SqlDbType.Int).Value = idAward;
                    if (command.ExecuteNonQuery() >= 1)
                    {
                        return "Награда с ID " + idAward + " успешно удалена!";
                    }
                    else
                    {
                        return "Не удалось удалить нагруду с ID " + idAward + "!";
                    }
                }
                catch (Exception exception)
                {
                    return exception.StackTrace;
                }
            }
        }

        public IEnumerable<Award> FindByTitle(string title)
        {
            List<SSU.ThreeLayer.Entities.Award> listAwards = new List<Entities.Award>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FindAward";
                command.Parameters.Add("title", SqlDbType.NVarChar).Value = title;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listAwards.Add(new Entities.Award((int)dataReader["idAward"], (string)dataReader["title"]));
                    }
                }
            }
            return listAwards;
        }

        public IEnumerable<Award> ShowAllAwards()
        {
            List<Award> listAwards = new List<Award>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllAwards";
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

        public IEnumerable<Award> SortByTitle()
        {
            List<Award> listAwards = new List<Award>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SortByTitle";
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
    }
}
