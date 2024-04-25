CREATE OR ALTER PROCEDURE League.GetTeamByName
	@TeamName NVARCHAR(32)
AS

SELECT *
FROM League.Team T
Where T.TeamName = @TeamName;