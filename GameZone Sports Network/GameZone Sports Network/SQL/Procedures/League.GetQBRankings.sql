CREATE OR ALTER PROCEDURE League.GetQBRankings
AS
BEGIN
    WITH RankedPlayers AS (
        SELECT
            p.PlayerID,
            p.PlayerName,
            p.Position,
            t.TeamName,
            ROW_NUMBER() OVER (ORDER BY o.PassTD DESC) AS PlayerRank
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
        r.PlayerRank,
        r.PlayerName,
        r.Position,
        r.TeamName,
		o.PassTD
    FROM
        RankedPlayers r
	INNER JOIN League.OffensivePlayerStats o ON o.PlayerID = r.PlayerID 
    ORDER BY
        r.PlayerRank;
END;