using System;
using Microsoft.EntityFrameworkCore;
using View.Models.Entities;

namespace View.Models;

public class AppDbContext : DbContext
{
    // this is where tables are defined
    public DbSet<Absence> Absences { get; set; }
    public DbSet<Average> Averages { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Year> Years { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // SqlServer authentication
        // optionsBuilder.UseSqlServer("Data Source = myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;").LogTo(Console.WriteLine);

        // Windows authentication (the one we use)
        optionsBuilder
            .UseSqlServer("Server=localhost;Database=Scoala;Integrated Security=SSPI;TrustServerCertificate=True;")
            .LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // this is where relationships are defined
    }
}