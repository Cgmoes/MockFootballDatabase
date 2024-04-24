CREATE OR ALTER PROCEDURE League.CreatePlayer
   @PlayerName NVARCHAR(32),
   @PositionID INT,
   @Position NVARCHAR(32),
   @Age INT,
   @JerseyNumber INT,
   @CollegeName NVARCHAR(32),
   @HomeState NVARCHAR(32),
   @Height INT
AS

INSERT League.Player(PlayerName, PositionID, Position, Age, JerseyNumber, CollegeName, HomeState, Height)
VALUES(@PlayerName, @PositionID, @Position, @Age, @JerseyNumber, @CollegeName, @HomeState, @Height);
GO