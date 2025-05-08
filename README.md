# SchoolPlatform

WPF app connected directly to a database. This is a school platform where teachers can create classes and students can join them. The teachers can also grade the students, update their attendance and all that. 

You will need to go to the [AppDbContext.cs](SchoolPlatform/Models/AppDbContext.cs) and update the connection string to your SQL database. The first thing the app tries to do is to access the database, so be nice to it and create one. Use the Entity Framework migrations to create the database structure.