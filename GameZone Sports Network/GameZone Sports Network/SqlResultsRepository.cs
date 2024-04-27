using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
                        command.Parameters.AddWithValue("HomeTeam", homeTeam);
                        command.Parameters.AddWithValue("TeamPlayed", teamPlayed);
                        command.Parameters.AddWithValue("PointsScored", pointsScored);
                        command.Parameters.AddWithValue("PointsAgainst", pointsAgainst);

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();
                    }
                }
            }   
        }

        public List<string> GetResultsByWeek(int weekNumber)
        {
            List<string> teamInfoList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("League.GetResultsByWeek", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@WeekNumber", weekNumber);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teamInfoList.Add($"Home Team: {reader["Home Team"]}\tAway Team: {reader["Away Team"]}\tScore: {reader["Home Score"]}-{reader["Away Score"]}");
                        }
                    }
                } 
            }
            return teamInfoList;
        }

        public List<string> ShowStandings() 
        {
            List<string> results = new List<string>();
            int count = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("League.ShowStandings", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count++;
                            string teamName = reader["Team"].ToString()!;

                            results.Add($"{count}. Team: {teamName} \tRecord: {reader["Wins"]}-{reader["Ties"]}-{reader["Losses"]}");
                        }
                    }
                }
            }
            return results;
        }

        public List<string> RankQBs() 
        {
            List<string> results = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("League.GetQBRankings", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add($"{reader["PlayerRank"]}.{reader["PlayerName"]} - ({reader["TeamName"]}) \tTouchdowns: {reader["PassTD"]}");
                        }
                    }
                }
            }
            return results;
        }
    }
}
