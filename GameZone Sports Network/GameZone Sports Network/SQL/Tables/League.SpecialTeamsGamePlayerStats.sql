   IF OBJECT_ID(N'League.SpecialTeamsGamePlayerStats') IS NULL
BEGIN
CREATE TABLE League.SpecialTeamsGamePlayerStats
(
	GameID INT NOT NULL FOREIGN KEY
		REFERENCES League.Game(GameID),
	PlayerID INT NOT NULL FOREIGN KEY
		REFERENCES League.PlayerTeam(PlayerTeamID),
	FieldGoalAtt INT NULL,
	FieldGoalsMade INT NULL,
	Punts INT NULL,
	PuntYrds INT NULL
);
END