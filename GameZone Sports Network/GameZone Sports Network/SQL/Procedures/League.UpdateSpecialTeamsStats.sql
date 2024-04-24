CREATE OR ALTER PROCEDURE League.UpdateSpecialTeamsStats
	@PlayerID INT,
	@FieldGoalAttempts INT,
	@FieldGoalsMade INT,
	@Punts INT,
	@PuntYards INT
AS

UPDATE League.SpecialTeamsStats
SET FieldGoalAttempts = @FieldGoalAttempts,
	FieldGoalsMade = @FieldGoalsMade,
	Punts = @Punts,
	PuntYrds = @PuntYards
WHERE PlayerID = @PlayerID;
GO