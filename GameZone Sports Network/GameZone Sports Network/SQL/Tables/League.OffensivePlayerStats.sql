IF OBJECT_ID(N'League.OffensivePlayerStats') IS NULL
BEGIN
	CREATE TABLE League.OffensivePlayerStats
	(
		OffensiveID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		PlayerID INT NOT NULL FOREIGN KEY
			REFERENCES League.Player(PlayerID),
		PassAttempts INT NULL,
		PassCompletions INT NULL,
		PassYards INT NULL,
		PassTD INT NULL,
		Ints INT NULL,
		RushYrds INT NULL,
		RushAttempts INT NULL,
		Receptions INT NULL,
		RecievingYrds INT NULL,
		Touchdowns INT NULL,
		Fumbles INT NULL
	)
END;