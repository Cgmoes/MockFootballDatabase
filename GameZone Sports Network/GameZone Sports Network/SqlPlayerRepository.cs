using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using Data;
using Data.Models;

namespace GameZone_Sports_Network
{
    public class SqlPlayerRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="connectionString">the connection information to the database</param>
        public SqlPlayerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Creates a player to add to the database
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="posID">The position ID of the player</param>
        /// <param name="pos">The position of the player</param>
        /// <param name="age">The age of the player</param>
        /// <param name="jerseyNum">The player's number</param>
        /// <param name="college">The player's alma mater</param>
        /// <param name="state">The state where the player is from</param>
        /// <param name="height">The height of the player in inches</param>
        /// <param name="teamID">the ID of the team the player is on</param>
        /// <returns>The player that was created</returns>
        public Player CreatePlayer(string name, int posID, string pos, int age, int jerseyNum, string college, string state, int height, int teamID) 
        {
            using (var transaction = new TransactionScope()) 
            {
                using (var connection = new SqlConnection(connectionString)) 
                {
                    using (var command = new SqlCommand("League.CreatePlayer", connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("PlayerName", name);
                        command.Parameters.AddWithValue("PositionID", posID);
                        command.Parameters.AddWithValue("Position", pos);
                        command.Parameters.AddWithValue("Age", age);
                        command.Parameters.AddWithValue("JerseyNumber", jerseyNum);
                        command.Parameters.AddWithValue("CollegeName", college);
                        command.Parameters.AddWithValue("HomeState", state);
                        command.Parameters.AddWithValue("Height", height);
                        command.Parameters.AddWithValue("TeamID", teamID);

                        var p = command.Parameters.Add("PlayerID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();
                        
                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var playerId = (int)command.Parameters["PlayerID"].Value;

                        return new Player(playerId, name, posID, pos, age, jerseyNum, college, state, height, teamID);
                    }
                }
            }
        }

        public Player UpdatePlayer(int playerId, string name, int posID, string pos, int age, int jerseyNum, string college, string state, int height, int teamID)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("League.SavePlayer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("PlayerName", name);
                        command.Parameters.AddWithValue("PositionID", posID);
                        command.Parameters.AddWithValue("Position", pos);
                        command.Parameters.AddWithValue("Age", age);
                        command.Parameters.AddWithValue("JerseyNumber", jerseyNum);
                        command.Parameters.AddWithValue("CollegeName", college);
                        command.Parameters.AddWithValue("HomeState", state);
                        command.Parameters.AddWithValue("Height", height);
                        command.Parameters.AddWithValue("TeamID", teamID);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        return new Player(playerId, name, posID, pos, age, jerseyNum, college, state, height, teamID);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a player by their name
        /// </summary>
        /// <param name="name">The name of the player to find</param>
        /// <returns>The player with that name</returns>
        /// <exception cref="RecordNotFoundException">Thrown if the player with that name doesn't exist</exception>
        public Player GetPlayer(string name) 
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                using (var command = new SqlCommand("League.GetPlayerByName", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("PlayerName", name);

                    connection.Open();

                    using (var reader = command.ExecuteReader()) 
                    {
                        var player = TranslatePlayer(reader);

                        if (player == null) throw new RecordNotFoundException(name);

                        return player;
                    }
                }
            }
        }

        private Player? TranslatePlayer(SqlDataReader reader) 
        {
            var playerIdOrdinal = reader.GetOrdinal("PlayerID");
            var nameOrdinal = reader.GetOrdinal("PlayerName");
            var positionIdOrdinal = reader.GetOrdinal("PositionID");
            var positionOrdinal = reader.GetOrdinal("Position");
            var ageOrdinal = reader.GetOrdinal("Age");
            var jerseyNumberOrdinal = reader.GetOrdinal("JerseyNumber");
            var collegeNameOrdinal = reader.GetOrdinal("CollegeName");
            var homeStateOrdinal = reader.GetOrdinal("HomeState");
            var heightOrdinal = reader.GetOrdinal("Height");
            var teamOrdinal = reader.GetOrdinal("TeamID");

            if (!reader.Read()) return null;

            return new Player(
                reader.GetInt32(playerIdOrdinal),
                reader.GetString(nameOrdinal),
                reader.GetInt32(positionIdOrdinal),
                reader.GetString(positionOrdinal),
                reader.GetInt32(ageOrdinal),
                reader.GetInt32(jerseyNumberOrdinal),
                reader.GetString(collegeNameOrdinal),
                reader.GetString(homeStateOrdinal),
                reader.GetInt32(heightOrdinal),
                reader.GetInt32(teamOrdinal)
                );
        }

        public IReadOnlyList<Player> GetPlayers() 
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                using (var command = new SqlCommand("League.GetPlayers", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader()) return TranslatePlayers(reader);
                }
            }
        }

        public IReadOnlyList<Player> GetPlayersByTeam(int teamId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("League.GetPlayerByTeam", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("teamId", teamId);

                    connection.Open();

                    using (var reader = command.ExecuteReader()) return TranslatePlayers(reader);
                }
            }
        }

        public int GetTotalPlayers(int teamId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("League.GetTotalPlayers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("teamId", teamId);

                    connection.Open();

                    return (int)command.ExecuteScalar();
                }
            }
        }

        private IReadOnlyList<Player> TranslatePlayers(SqlDataReader reader) 
        {
            var players = new List<Player>();

            var playerIdOrdinal = reader.GetOrdinal("PlayerID");
            var teamIdOrdinal = reader.GetOrdinal("TeamID");
            var playerNameOrdinal = reader.GetOrdinal("PlayerName");
            var positionIdOrdinal = reader.GetOrdinal("PositionID");
            var positionOrdinal = reader.GetOrdinal("Position");
            var ageOrdinal = reader.GetOrdinal("Age");
            var jerseyNumOrdinal = reader.GetOrdinal("JerseyNumber");
            var collegeNameOrdinal = reader.GetOrdinal("CollegeName");
            var homeStateOrdinal = reader.GetOrdinal("HomeState");
            var heightOrdinal = reader.GetOrdinal("height");

            while(reader.Read()) 
            {
                players.Add(new Player(
                    reader.GetInt32(playerIdOrdinal),
                    reader.GetString(playerNameOrdinal),
                    reader.GetInt32(positionIdOrdinal),
                    reader.GetString(positionOrdinal),
                    reader.GetInt32(ageOrdinal),
                    reader.GetInt32(jerseyNumOrdinal),
                    reader.GetString(collegeNameOrdinal),
                    reader.GetString(homeStateOrdinal),
                    reader.GetInt32(heightOrdinal),
                    reader.GetInt32(teamIdOrdinal)
                    ));
            }

            return players;
        }
    }
}
