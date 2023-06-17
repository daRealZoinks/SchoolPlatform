using View.Models.Entities;

namespace View.Models.Repositories;

public class StudentRepository : RepositoryBase<Student>
{
    public StudentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}