-- create a new stored procedure that adds a new specialization to the database
-- rows:
--	1. Id int
--	2. Value int

CREATE PROCEDURE [dbo].[spAddYear]
	@Id int,
	@Value int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
INSERT INTO [dbo].[Years] ([Id], [Value])
VALUES (@Id, @Value)
END

-- create a new stored procedure that removes a specialization from the database

CREATE PROCEDURE [dbo].[spRemoveYear]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
DELETE
FROM [dbo].[Years]
WHERE [Id] = @Id
END

-- create a new stored procedure that updates a specialization from the database with new information

CREATE PROCEDURE [dbo].[spUpdateYear]
	@Id int,
	@Value int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
UPDATE [dbo].[Years]
SET [Value] = @Value
WHERE [Id] = @Id
END
