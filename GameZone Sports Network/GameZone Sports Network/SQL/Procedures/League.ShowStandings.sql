CREATE OR ALTER PROCEDURE League.ShowStandings
AS
BEGIN
    SELECT HomeTeam,
           SUM(CASE WHEN PointsScored > PointsAgainst THEN 1 ELSE 0 END) AS Wins,
		   SUM(CASE WHEN PointsScored = PointsAgainst THEN 1 ELSE 0 END) AS Ties,
           SUM(CASE WHEN PointsScored < PointsAgainst THEN 1 ELSE 0 END) AS Losses
    FROM League.Results
    GROUP BY HomeTeam
	ORDER BY Wins Desc, Ties Desc, Losses Asc
END;