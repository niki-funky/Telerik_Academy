--01. Create a table in SQL Server with 10 000 000 log entries
-- (date + text). Search in the table by date range. 
-- Check the speed (without caching).

USE master
GO

CREATE DATABASE PerformanceDB
GO

USE PerformanceDB
GO

CREATE TABLE Logs(
  LogId int NOT NULL PRIMARY KEY IDENTITY,
  LogDate date,
  LogText varchar(100),
)
INSERT INTO Logs(LogDate) VALUES ('10.10.2012')

SET NOCOUNT ON
DECLARE @day int= 1
DECLARE @month int= 1
DECLARE @year int= 2000
DECLARE @logDate datetime
--start while loop
DECLARE @RowCount int = 1000000
WHILE @RowCount > 0
BEGIN
	IF @day > 28 
	BEGIN
		SET @day = 1
		SET @month = @month + 1
	END
	IF @month > 12
	BEGIN
		SET @month = 1
		SET @year = @year + 1
	END
	SET @day = @day + 1
	SET @logDate = CONVERT(datetime, 
		CONVERT(varchar(2),@day) + '.' +
		CONVERT(varchar(2),@month) + '.' +
		CONVERT(varchar(4),@year),
		104)
	INSERT INTO Logs(LogDate, LogText)
	VALUES(
		@logDate, 
		'text(' +
		CONVERT(varchar(14), @logDate) +
		')' + 
		CONVERT(varchar(8),@RowCount)
		)

SET @RowCount = @RowCount - 1
END
--end loop
SET NOCOUNT OFF

--select from to year
SELECT * FROM Logs
WHERE LogDate > '2000' and LogDate < '2100'

--02. Add an index to speed-up the search by date. 
--Test the search speed (after cleaning the cache).

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)

SELECT * FROM Logs
WHERE LogDate > '2000' and LogDate < '2100'

--drops index
DROP INDEX IDX_Logs_LogDate ON Logs

--03.Add a full text index for the text column. 
--Try to search with and without the full-text index 
--and compare the speed.

CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE UNIQUE INDEX PK_Logs_LogText ON Logs(LogText);

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs_LogText
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT COUNT(*) FROM Logs
WHERE CONTAINS(LogText, 'Mar')

--04. Create the same table in MySQL and partition it by date 
--(1990, 2000, 2010). Fill 1 000 000 log entries. Compare the 
--searching speed in all partitions (random dates) to certain 
--partition (e.g. year 1995).
