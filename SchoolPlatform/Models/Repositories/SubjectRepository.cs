using View.Models.Entities;

namespace View.Models.Repositories;

public class SubjectRepository : RepositoryBase<Subject>
{
    public SubjectRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}