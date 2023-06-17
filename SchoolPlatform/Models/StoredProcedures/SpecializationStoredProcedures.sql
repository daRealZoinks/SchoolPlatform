-- create a new stored procedure that adds a new specialization to the database
-- rows:
--	1. Id int
--	2. Name nvarchar(max)

CREATE PROCEDURE [dbo].[spAddSpecialization]
	@Id int,
	@Name nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
INSERT INTO [dbo].[Specializations] ([Id], [Name])
VALUES (@Id, @Name)
END

-- create a new stored procedure that removes a specialization from the database

CREATE PROCEDURE [dbo].[spRemoveSpecialization]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
DELETE
FROM [dbo].[Specializations]
WHERE [Id] = @Id
END

-- create a new stored procedure that updates a specialization from the database with new information

CREATE PROCEDURE [dbo].[spUpdateSpecialization]
	@Id int,
	@Name nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
UPDATE [dbo].[Specializations]
SET [Name] = @Name
WHERE [Id] = @Id
END
