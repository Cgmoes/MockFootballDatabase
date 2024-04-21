CREATE OR ALTER PROCEDURE League.FetchPlayer
   @PlayerID INT
AS

SELECT P.PlayerID, P.PlayerName, P.Position, P.Age, P.JerseyNumber, P.CollegeName, P.HomeState, P.Height
FROM League.Player P
WHERE P.PlayerID = @PlayerID;
GO
