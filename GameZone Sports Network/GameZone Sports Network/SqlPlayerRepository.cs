using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Data;
using Data.Models;

namespace GameZone_Sports_Network
{
    public class SqlPlayerRepository
    {
        private readonly string connectionString;

        public SqlPlayerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Player CreatePlayer(string name, int posID, string pos, int age, int jerseyNum, string college, string state, int height) 
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

                        var p = command.Parameters.AddWithValue("PlayerID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();
                        
                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var personID = (int)command.Parameters["PersonID"].Value;

                        return new Player(personID, name, posID, pos, age, jerseyNum, college, state, height);
                    }
                }
            }
        }

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
                reader.GetInt32(heightOrdinal)
                );
        }
    }
}
