IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'League'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [League] AUTHORIZATION [dbo]');
END;