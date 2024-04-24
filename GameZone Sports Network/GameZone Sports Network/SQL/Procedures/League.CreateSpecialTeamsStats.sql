CREATE OR ALTER PROCEDURE League.CreateSpecialTeamsStats
	@PlayerID INT,
	@FieldGoalAttempts INT,
	@FieldGoalsMade INT,
	@Punts INT,
	@PuntYards INT
AS

INSERT League.SpecialTeamsStats(PlayerID, FieldGoalAttempts, FieldGoalsMade, Punts, PuntYrds)
VALUES(@PlayerID, @FieldGoalAttempts, @FieldGoalsMade, @Punts, @PuntYards);
GO