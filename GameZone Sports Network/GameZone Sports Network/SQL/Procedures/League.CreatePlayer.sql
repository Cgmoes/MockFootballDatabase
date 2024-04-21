CREATE OR ALTER PROCEDURE League.CreatePlayer
   @PlayerName NVARCHAR(32),
   @Position NVARCHAR(32),
   @Age NVARCHAR(128),
   @JerseyNumber INT,
   @CollegeName NVARCHAR(32),
   @HomeState NVARCHAR(32),
   @Height INT
AS

INSERT League.Player(PlayerName, Position, Age, JerseyNumber, CollegeName, HomeState, Height)
VALUES(@PlayerName, @Position, @Age, @JerseyNumber, @CollegeName, @HomeState, @Height);

SET @PlayerId = SCOPE_IDENTITY();
GO
