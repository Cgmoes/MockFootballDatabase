CREATE OR ALTER PROCEDURE League.GetQBRankings
AS
BEGIN
    WITH RankedPlayers AS (
        SELECT
            p.PlayerID,
            p.PlayerName,
            p.Position,
            t.TeamName,
            ROW_NUMBER() OVER (ORDER BY o.Touchdowns DESC) AS PlayerRank
        FROM
            League.Player p
        INNER JOIN
            League.Team t ON p.TeamID = t.TeamID
		INNER JOIN 
		    League.OffensivePlayerStats o ON o.PlayerID = p.PlayerID
        WHERE
            p.Position = 'QB'
    )
    SELECT
        PlayerRank,
        PlayerName,
        Position,
        TeamName
    FROM
        RankedPlayers
    ORDER BY
        PlayerRank;
END;