   IF OBJECT_ID(N'League.OffensiveGamePlayerStats') IS NULL
BEGIN
CREATE TABLE League.OffensiveGamePlayerStats
(
	GameID INT NOT NULL FOREIGN KEY
		REFERENCES League.Game(GameID),
	PlayerID INT NOT NULL FOREIGN KEY
		REFERENCES League.PlayerTeam(PlayerTeamID),
	PassAttempts INT NULL,
	PassCompletions INT NULL,
	PassYards INT NULL,
	PassTDs INT NULL,
	Ints INT NULL,
	RushYrds INT NULL,
	RushAttempts INT NULL,
	Receptions INT NULL,
	RecievingYrds INT NULL,
	RushTDs INT NULL,
	RecievingTDs INT NULL,
	Fumbles INT NULL
);
END