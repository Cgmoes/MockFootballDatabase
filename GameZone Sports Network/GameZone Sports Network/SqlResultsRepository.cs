using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GameZone_Sports_Network
{
    public class SqlResultsRepository
    {
        private readonly string connectionString;

        public SqlResultsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateResults(int week, string homeTeam, string teamPlayed, int pointsScored, int pointsAgainst) 
        {
            using (var transaction = new TransactionScope()) 
            { 
                using (var connection = new SqlConnection(connectionString)) 
                {
                    using (var command = new SqlCommand("League.CreateResults", connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("WeekNumber", week);
                        command.Parameters.AddWithValue("TeamPlayed", teamPlayed);
                        command.Parameters.AddWithValue("TeamPlayed", homeTeam);
                        command.Parameters.AddWithValue("PointsScored", pointsScored);
                        command.Parameters.AddWithValue("PointsAgainst", pointsAgainst);

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();
                    }
                }
            }   
        }
    }
}
