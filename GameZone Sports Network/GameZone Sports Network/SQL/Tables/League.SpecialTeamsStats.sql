IF OBJECT_ID(N'League.SpecialTeamsStats') IS NULL
BEGIN
CREATE TABLE League.SpecialTeamsStats
(
	SpecialTeamsID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	PlayerID INT NOT NULL FOREIGN KEY
		REFERENCES League.Player(PlayerID),
	FieldGoalAttempts INT NULL,
	FieldGoalsMade INT NULL,
	Punts INT NULL,
	PuntYrds INT NULL
)
END;