using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GameZone_Sports_Network
{
    public class SqlStatsRepository
    {
        private readonly string connectionString;

        public SqlStatsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateOffensiveStats(int playerId, int passAttempts,
            int completions, int passYards, int passTds, int ints, int RushYrds,
            int rushAttempts, int receptions, int receivingYrds, int tds, int fumbles)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("League.CreateOffensiveStats", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("PlayerID", playerId);
                        command.Parameters.AddWithValue("PassAttempts", passAttempts);
                        command.Parameters.AddWithValue("PassCompletions", completions);
                        command.Parameters.AddWithValue("PassYards", passYards);
                        command.Parameters.AddWithValue("PassTD", passTds);
                        command.Parameters.AddWithValue("Ints", ints);
                        command.Parameters.AddWithValue("RushYrds", RushYrds);
                        command.Parameters.AddWithValue("RushAttempts", rushAttempts);
                        command.Parameters.AddWithValue("Receptions", receptions);
                        command.Parameters.AddWithValue("RecievingYrds", receivingYrds);
                        command.Parameters.AddWithValue("Touchdowns", tds);
                        command.Parameters.AddWithValue("Fumbles", fumbles);

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();
                    }
                }
            }
        }

        public void CreateDefensiveStats(int playerID, int tackles, int sacks, int ints, int fumbles, int tds)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("League.CreateDefensiveStats", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("PlayerID", playerID);
                        command.Parameters.AddWithValue("Tackles", tackles);
                        command.Parameters.AddWithValue("Sacks", sacks);
                        command.Parameters.AddWithValue("Interceptions", ints);
                        command.Parameters.AddWithValue("Fumbles", fumbles);
                        command.Parameters.AddWithValue("TDs", tds);

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();
                    }
                }
            }
        }

        public void CreateSpecialTeamsStats(int playerID, int fgAttempts, int fgMade, int punts, int puntYards)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("League.CreateDefensiveStats", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("PlayerID", playerID);
                        command.Parameters.AddWithValue("FieldGoalAttempts", fgAttempts);
                        command.Parameters.AddWithValue("FieldGoalsMade", fgMade);
                        command.Parameters.AddWithValue("Punts", punts);
                        command.Parameters.AddWithValue("PuntYrds", puntYards);

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();
                    }
                }
            }
        }
    }
}
