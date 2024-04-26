CREATE OR ALTER PROCEDURE League.CreateSpecialTeamsStats
	@PlayerID INT,
    @FieldGoalAttempts INT,
    @FieldGoalsMade INT,
    @Punts INT,
    @PuntYards INT,
	@SpecialTeamsID INT OUTPUT
AS
BEGIN
    MERGE INTO League.SpecialTeamsStats AS Target
    USING (VALUES (@PlayerID)) AS Source(PlayerID)
    ON Target.PlayerID = Source.PlayerID
    WHEN MATCHED THEN
        UPDATE SET
            FieldGoalAttempts = @FieldGoalAttempts,
            FieldGoalsMade = @FieldGoalsMade,
            Punts = @Punts,
            PuntYrds = @PuntYards
    WHEN NOT MATCHED THEN
        INSERT (PlayerID, FieldGoalAttempts, FieldGoalsMade, Punts, PuntYrds)
        VALUES (@PlayerID, @FieldGoalAttempts, @FieldGoalsMade, @Punts, @PuntYards);
SET @SpecialTeamsID = SCOPE_IDENTITY()
END;