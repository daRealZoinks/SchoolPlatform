using View.Models.Entities;

namespace View.Models.Repositories;

public class GradeRepository : RepositoryBase<Grade>
{
    public GradeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}