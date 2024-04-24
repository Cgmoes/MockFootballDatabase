CREATE OR ALTER PROCEDURE League.GetPlayerByName
	@PlayerName NVARCHAR(32)
AS

SELECT *
FROM League.Player P
Where P.PlayerName = @PlayerName