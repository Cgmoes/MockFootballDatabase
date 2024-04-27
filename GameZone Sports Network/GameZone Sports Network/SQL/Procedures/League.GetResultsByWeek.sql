--Creates the results procedure that takes in a given week
--and shows all the results for that game week
CREATE OR ALTER PROCEDURE League.GetResultsByWeek
	@WeekNumber INT
AS
BEGIN

    -- Retrieve results for each team for the specified week
    SELECT R.HomeTeam AS N'Home Team', R.TeamPlayed AS N'Away Team', 
	R.PointsScored AS N'Home Score', R.PointsAgainst AS N'Away Score',
	SUM(R.PointsAgainst + R.PointsScored) AS TotalPoints
    FROM League.Results R
	WHERE R.WeekNumber = @WeekNumber
	GROUP BY R.HomeTeam, R.TeamPlayed, R.PointsAgainst, R.PointsScored
END;