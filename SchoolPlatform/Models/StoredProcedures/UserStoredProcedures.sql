-- create a new stored procedure that adds a new user to the database
-- rows:
--	1. Id int
--	2. Username nvarchar(max)
--	3. Password nvarchar(max)
--	4. Role (int)
--	5. EntityId (int)

CREATE PROCEDURE [dbo].[spAddUser]
	@Id int,
	@Username nvarchar(max),
	@Password nvarchar(max),
	@Role int,
	@EntityId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [Role], [EntityId])
VALUES (@Id, @Username, @Password, @Role, @EntityId)
END

-- create a new stored procedure that removes a user from the database

CREATE PROCEDURE [dbo].[spRemoveUser]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
DELETE
FROM [dbo].[Users]
WHERE [Id] = @Id
END

-- create a new stored procedure that updates a user from the database with new information

CREATE PROCEDURE [dbo].[spUpdateUser]
	@Id int,
	@Username nvarchar(max),
	@Password nvarchar(max),
	@Role int,
	@EntityId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET
NOCOUNT ON;
	-- Insert statements for procedure here
UPDATE [dbo].[Users]
SET [Username] = @Username, [Password] = @Password, [Role] = @Role, [EntityId] = @EntityId
WHERE [Id] = @Id
END
