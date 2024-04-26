CREATE OR ALTER PROCEDURE League.ShowStandings
AS
BEGIN
    SELECT Team,
           SUM(Wins) AS Wins,
		   SUM(Ties) AS Ties,
           SUM(Losses) AS Losses
    FROM (
        SELECT HomeTeam AS Team,
               SUM(CASE WHEN PointsScored > PointsAgainst THEN 1 ELSE 0 END) AS Wins,
		       SUM(CASE WHEN PointsScored = PointsAgainst THEN 1 ELSE 0 END) AS Ties,
               SUM(CASE WHEN PointsScored < PointsAgainst THEN 1 ELSE 0 END) AS Losses
        FROM League.Results
        GROUP BY HomeTeam
        UNION ALL
        SELECT TeamPlayed AS Team,
               SUM(CASE WHEN PointsScored < PointsAgainst THEN 1 ELSE 0 END) AS Wins,
		       SUM(CASE WHEN PointsScored = PointsAgainst THEN 1 ELSE 0 END) AS Ties,
               SUM(CASE WHEN PointsScored > PointsAgainst THEN 1 ELSE 0 END) AS Losses
        FROM League.Results
        GROUP BY TeamPlayed
    ) AS CombinedResults
    GROUP BY Team
    ORDER BY Wins DESC, Ties DESC, Losses ASC;
END;