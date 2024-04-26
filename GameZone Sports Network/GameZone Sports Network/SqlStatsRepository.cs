using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Data.Models;
using Data;

namespace GameZone_Sports_Network
{
    public class SqlStatsRepository
    {
        private readonly string connectionString;

        public SqlStatsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DefensiveGamePlayerStats CreateDefensiveTeamsStats(int playerID, int tackles, int sacks, int ints, int fumbles, int tds)
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

                        var t = command.Parameters.Add("DefensiveID", SqlDbType.Int);
                        t.Direction = ParameterDirection.Output;

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();

                        int teamId;
                        if (command.Parameters["DefensiveID"].Value != DBNull.Value)
                        {
                            teamId = (int)command.Parameters["DefensiveID"].Value;
                        }
                        else
                        {
                            DefensiveGamePlayerStats s = GetDefensiveStatsByPlayerId(playerID, connection);
                            teamId = s.DefensiveTeamID;
                        }

                        return new DefensiveGamePlayerStats(teamId, playerID, tackles, sacks, ints, fumbles, tds);
                    }
                }
            }
        }

        public SpecialTeamsGamePlayerStats CreateSpecialTeamsStats(int playerID, int fgAttempts, int fgMade, int punts, int puntYards)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("League.CreateSpecialTeamsStats", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("PlayerID", playerID);
                        command.Parameters.AddWithValue("FieldGoalAttempts", fgAttempts);
                        command.Parameters.AddWithValue("FieldGoalsMade", fgMade);
                        command.Parameters.AddWithValue("Punts", punts);
                        command.Parameters.AddWithValue("PuntYards", puntYards);

                        var t = command.Parameters.Add("SpecialTeamsID", SqlDbType.Int);
                        t.Direction = ParameterDirection.Output;

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();

                        int teamId;
                        if (command.Parameters["SpecialTeamsID"].Value != DBNull.Value)
                        {
                            teamId = (int)command.Parameters["SpecialTeamsID"].Value;
                        }
                        else 
                        {
                            SpecialTeamsGamePlayerStats s = GetSpecialStatsByPlayerId(playerID, connection);
                            teamId = s.SpecialTeamsId;
                        }

                        return new SpecialTeamsGamePlayerStats(teamId, playerID, fgAttempts, fgMade, punts, puntYards);
                    }
                }
            }
        }

        public OffensiveGamePlayerStats CreateOffensiveTeamsStats(int playerID, int passAtt, int passComp, int passYards, int passTd, int ints, int rushYrds, int rushAtt, int rec, int recYrds, int tds, int fumbles)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("League.CreateOffensiveStats", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("PlayerID", playerID);
                        command.Parameters.AddWithValue("PassAttempts", passAtt);
                        command.Parameters.AddWithValue("PassCompletions", passComp);
                        command.Parameters.AddWithValue("PassYards", passYards);
                        command.Parameters.AddWithValue("PassTD", passTd);
                        command.Parameters.AddWithValue("Ints", ints);
                        command.Parameters.AddWithValue("RushYrds", rushYrds);
                        command.Parameters.AddWithValue("RushAttempts", rushAtt);
                        command.Parameters.AddWithValue("Receptions", rec);
                        command.Parameters.AddWithValue("RecievingYrds", recYrds);
                        command.Parameters.AddWithValue("Touchdowns", tds);
                        command.Parameters.AddWithValue("Fumbles", fumbles);

                        var t = command.Parameters.Add("OffensiveTeamID", SqlDbType.Int);
                        t.Direction = ParameterDirection.Output;

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();

                        int teamId;
                        if (command.Parameters["OffensiveTeamID"].Value != DBNull.Value)
                        {
                            teamId = (int)command.Parameters["OffensiveTeamID"].Value;
                        }
                        else
                        {
                            OffensiveGamePlayerStats s = GetOffensiveStatsByPlayerId(playerID, connection);
                            teamId = s.OffensiveID;
                        }

                        return new OffensiveGamePlayerStats(teamId, playerID, passAtt, passComp, passYards, passTd, ints, rushYrds, rushAtt, rec, recYrds, tds, fumbles);
                    }
                }
            }
        }

        public SpecialTeamsGamePlayerStats GetSpecialStatsByPlayerId(int playerId, SqlConnection c)
        {
                using (var command = new SqlCommand("League.GetSpecialTeamsID", c))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("PlayerID", playerId);


                    using (var reader = command.ExecuteReader())
                    {
                        var stats = TranslateSpecialStats(reader);

                        return stats!;
                    }
                }
        }

        private SpecialTeamsGamePlayerStats? TranslateSpecialStats(SqlDataReader reader)
        {
            var IdOrdinal = reader.GetOrdinal("SpecialTeamsID");
            var playerIdOrdinal = reader.GetOrdinal("PlayerID");
            var fgAttemptsOrdinal = reader.GetOrdinal("FieldGoalAttempts");
            var fgMadeOrdinal = reader.GetOrdinal("FieldGoalsMade");
            var puntsOrdinal = reader.GetOrdinal("Punts");
            var punttYardsOrdinal = reader.GetOrdinal("PuntYrds");

            if (!reader.Read()) return null;

            return new SpecialTeamsGamePlayerStats(
                reader.GetInt32(IdOrdinal),
                reader.GetInt32(playerIdOrdinal),
                reader.GetInt32(fgAttemptsOrdinal),
                reader.GetInt32(fgMadeOrdinal),
                reader.GetInt32(puntsOrdinal),
                reader.GetInt32(punttYardsOrdinal)
                );
        }

        private DefensiveGamePlayerStats? TranslateDefensiveStats(SqlDataReader reader)
        {
            var IdOrdinal = reader.GetOrdinal("DefensiveID");
            var playerIdOrdinal = reader.GetOrdinal("PlayerID");
            var tacklesOrdinal = reader.GetOrdinal("Tackles");
            var sacksOrdinal = reader.GetOrdinal("Sacks");
            var intsOrdinal = reader.GetOrdinal("Interceptions");
            var fumblesOrdinal = reader.GetOrdinal("Fumbles");
            var tdOrdinal = reader.GetOrdinal("TDs");

            if (!reader.Read()) return null;

            return new DefensiveGamePlayerStats(
                reader.GetInt32(IdOrdinal),
                reader.GetInt32(playerIdOrdinal),
                reader.GetInt32(tacklesOrdinal),
                reader.GetInt32(sacksOrdinal),
                reader.GetInt32(intsOrdinal),
                reader.GetInt32(fumblesOrdinal),
                reader.GetInt32(tdOrdinal)
                );
        }
        public DefensiveGamePlayerStats GetDefensiveStatsByPlayerId(int playerId, SqlConnection c)
        {
            using (var command = new SqlCommand("League.GetDefensiveStatID", c))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("PlayerID", playerId);


                using (var reader = command.ExecuteReader())
                {
                    var stats = TranslateDefensiveStats(reader);

                    return stats!;
                }
            }
        }


        public OffensiveGamePlayerStats GetOffensiveStatsByPlayerId(int playerId, SqlConnection c)
        {
            using (var command = new SqlCommand("League.GetOffensiveStatID", c))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("PlayerID", playerId);


                using (var reader = command.ExecuteReader())
                {
                    var stats = TranslateOffensiveStats(reader);

                    return stats!;
                }
            }
        }
        private OffensiveGamePlayerStats? TranslateOffensiveStats(SqlDataReader reader)
        {
            var IdOrdinal = reader.GetOrdinal("OffensiveID");
            var playerIdOrdinal = reader.GetOrdinal("PlayerID");
            var passAttemptsOrdinal = reader.GetOrdinal("PassAttempts");
            var completionsOrdinal = reader.GetOrdinal("PassCompletions");
            var passYardsOrdinal = reader.GetOrdinal("PassYards");
            var passTDsOrdinal = reader.GetOrdinal("PassTD");
            var IntsOrdinal = reader.GetOrdinal("Ints");
            var rushYardsOrdinal = reader.GetOrdinal("RushYrds");
            var rushAttemptsOrdinal = reader.GetOrdinal("RushAttempts");
            var receptionsOrdinal = reader.GetOrdinal("Receptions");
            var recYardsOrdinal = reader.GetOrdinal("RecievingYrds");
            var tdOrdinal = reader.GetOrdinal("Touchdowns");
            var fumblesOrdinal = reader.GetOrdinal("Fumbles");

            if (!reader.Read()) return null;

            return new OffensiveGamePlayerStats(
                reader.GetInt32(IdOrdinal),
                reader.GetInt32(playerIdOrdinal),
                reader.GetInt32(passAttemptsOrdinal),
                reader.GetInt32(completionsOrdinal),
                reader.GetInt32(passYardsOrdinal),
                reader.GetInt32(passTDsOrdinal),
                reader.GetInt32(IntsOrdinal),
                reader.GetInt32(rushYardsOrdinal),
                reader.GetInt32(rushAttemptsOrdinal),
                reader.GetInt32(receptionsOrdinal),
                reader.GetInt32(recYardsOrdinal),
                reader.GetInt32(tdOrdinal),
                reader.GetInt32(fumblesOrdinal)
                );
        }
    }
}
