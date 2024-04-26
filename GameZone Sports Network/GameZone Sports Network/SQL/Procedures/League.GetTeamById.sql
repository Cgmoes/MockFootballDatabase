CREATE OR ALTER PROCEDURE League.GetTeamById
	@TeamID INT
AS

SELECT T.TeamName
FROM League.Team T
Where T.TeamID = @TeamID