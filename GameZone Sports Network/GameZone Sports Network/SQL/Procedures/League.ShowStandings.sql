CREATE OR ALTER PROCEDURE League.ShowStandings
AS
--Rank the teama by wins
--Show wins, losses, points for, and points against
WITH WinsCTE AS (
	SELECT Count(*) As Wins, R.ResultID
	From League.Results R
	WHERE R.PointsScored > R.PointsAgainst
	GROUP BY R.ResultID
),
LossesCTE AS (
	SELECT Count(*) As Losses, R.ResultID
	From League.Results R
	WHERE R.PointsScored < R.PointsAgainst
	GROUP BY R.ResultID
)

SELECT T.TeamName AS Team,
	   R.PointsScored AS N'Points Scored', 
	   R.PointsAgainst As N'Points Against'
FROM League.TeamResults TR
	INNER JOIN League.Team T ON T.TeamID = TR.TeamID
	INNER JOIN League.Results R ON R.ResultID = TR.ResultID
	INNER JOIN WinsCTE W ON W.ResultID = R.ResultID
	INNER JOIN LossesCTE L ON L.ResultID = W.ResultID
GROUP BY T.TeamName, R.PointsScored, R.PointsAgainst;
GO