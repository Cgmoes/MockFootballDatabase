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

        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="connectionString">the connection information to the database</param>
        public SqlTeamRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Creates a team to put into the database
        /// </summary>
        /// <param name="name">The team's name</param>
        /// <param name="city">the team's city</param>
        /// <param name="year">the year the team was established</param>
        /// <returns>The team that was created</returns>
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

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        return new Team(name, city, year);
                    }
                }
            }
        }

        public IReadOnlyList<string> RetrieveTeams() 
        {
            List<string> teamNames = new List<string>();
            using (var connection = new SqlConnection(connectionString)) 
            {
                using (var command = new SqlCommand("League.RetrieveTeams", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamName = reader["TeamName"].ToString();
                            teamNames.Add(teamName);
                        }
                    }
                }
            }
            return teamNames;
        }
    }
}
