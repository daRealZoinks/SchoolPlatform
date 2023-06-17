-- create a new stored procedure that adds a new teacher to the database
-- rows:
--	1. Id int
--	2. FirstName nvarchar(max)
--	3. LastName nvarchar(max)

CREATE PROCEDURE [dbo].[spAddTeacher]
	@Id int,
	@FirstName nvarchar(max),
	@LastName nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
INSERT INTO [dbo].[Teachers] ([Id], [FirstName], [LastName])
VALUES (@Id, @FirstName, @LastName)
END

-- create a new stored procedure that removes a teacher from the database

CREATE PROCEDURE [dbo].[spRemoveTeacher]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
DELETE
FROM [dbo].[Teachers]
WHERE [Id] = @Id
END

-- create a new stored procedure that updates a teacher from the database with new information

CREATE PROCEDURE [dbo].[spUpdateTeacher]
	@Id int,
	@FirstName nvarchar(max),
	@LastName nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
UPDATE [dbo].[Teachers]
SET [FirstName] = @FirstName, [LastName] = @LastName
WHERE [Id] = @Id
END
