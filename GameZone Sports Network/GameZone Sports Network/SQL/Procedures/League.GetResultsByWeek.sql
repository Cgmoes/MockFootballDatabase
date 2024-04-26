CREATE OR ALTER PROCEDURE League.GetResultsByWeek
	@WeekNumber INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Retrieve results for each team for the specified week
    SELECT R.HomeTeam AS N'Home Team', R.TeamPlayed AS N'Away Team', R.PointsScored AS N'Home Score', R.PointsAgainst AS N'Away Score'
    FROM League.Results R
	WHERE R.WeekNumber = @WeekNumber
	GROUP BY R.HomeTeam, R.TeamPlayed, R.PointsAgainst, R.PointsScored
END;