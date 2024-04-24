using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Data.Models;

namespace GameZone_Sports_Network
{
    public class SqlTeamRepository
    {
        private readonly string connectionString;

        public SqlTeamRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public Team CreateTeam(string name, string city, int year) 
        {
            using (var transaction = new TransactionScope()) 
            {
                using (var connection = new SqlConnection(connectionString)) 
                {
                    using (var command = new SqlCommand("League.CreateTeam", connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("TeamName", name);
                        command.Parameters.AddWithValue("TeamCity", city);
                        command.Parameters.AddWithValue("YearEstablished", year);

                        var t = command.Parameters.Add("TeamID", SqlDbType.Int);
                        t.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var teamId = (int)command.Parameters["TeamID"].Value;

                        return new Team(teamId, name, city, year);
                    }
                }
            }
        }
    }
}
