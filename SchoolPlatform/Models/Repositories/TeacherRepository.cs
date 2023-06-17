using View.Models.Entities;

namespace View.Models.Repositories;

public class TeacherRepository : RepositoryBase<Teacher>
{
    public TeacherRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}