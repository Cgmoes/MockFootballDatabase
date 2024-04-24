CREATE OR ALTER PROCEDURE League.GetResultsByWeek
	@Week INT
AS

SELECT T.TeamName AS Team, R.TeamPlayed AS Opponent, R.PointsScored, R.PointsAgainst
FROM League.Results R
	INNER JOIN League.TeamResults TR ON TR.ResultID = R.ResultID
	INNER JOIN League.Team T ON T.TeamID = TR.TeamID
WHERE R.WeekNumber = @Week
GROUP BY T.TeamName, R.TeamPlayed, R.PointsScored, R.PointsAgainst;