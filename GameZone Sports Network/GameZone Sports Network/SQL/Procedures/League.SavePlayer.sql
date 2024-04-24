CREATE OR ALTER PROCEDURE League.SavePlayer
	@PlayerName NVARCHAR(32),
	@PositionID INT,
	@Position NVARCHAR(32),
	@Age INT,
	@JerseyNumber INT,
	@CollegeName NVARCHAR(32),
	@HomeState NVARCHAR(32),
	@Height INT
AS

UPDATE League.Player
SET PositionID = @PositionID,
    Position = @Position,
    Age = @Age,
    JerseyNumber = @JerseyNumber,
    CollegeName = @CollegeName,
    HomeState = @HomeState,
    Height = @Height
WHERE PlayerName = @PlayerName;