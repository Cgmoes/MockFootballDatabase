   IF OBJECT_ID(N'League.Player') IS NULL
BEGIN
CREATE TABLE League.Player
(
	PlayerID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	PlayerName NVARCHAR(32) NOT NULL,
	Position NVARCHAR (32) NOT NULL,
	Age INT NOT NULL,
	JerseyNumber INT NOT NULL,
	CollegeName NVARCHAR(32) NOT NULL,
	HomeState NVARCHAR(32) NOT NULL,
	Height INT NOT NULL,

	CHECK(PlayerName > N'' OR Position > N'' OR CollegeName > N'' OR HomeState > N'')
);
END