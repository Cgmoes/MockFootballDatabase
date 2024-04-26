CREATE OR ALTER PROCEDURE League.CreatePlayer
   @PlayerName NVARCHAR(32),
   @PositionID INT,
   @Position NVARCHAR(32),
   @Age INT,
   @JerseyNumber INT,
   @CollegeName NVARCHAR(32),
   @HomeState NVARCHAR(32),
   @Height INT,
   @TeamID INT,
   @PlayerID INT OUTPUT
AS
BEGIN
INSERT INTO League.Player(PlayerName, PositionID, Position, Age, JerseyNumber, CollegeName, HomeState, Height, TeamID)
VALUES(@PlayerName, @PositionID, @Position, @Age, @JerseyNumber, @CollegeName, @HomeState, @Height, @TeamID);

    SET @PlayerID = SCOPE_IDENTITY()
END