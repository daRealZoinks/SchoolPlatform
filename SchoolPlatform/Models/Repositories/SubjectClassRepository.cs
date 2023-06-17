using View.Models.Entities;

namespace View.Models.Repositories;

public class SubjectClassRepository : RepositoryBase<SubjectClass>
{
    public SubjectClassRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}