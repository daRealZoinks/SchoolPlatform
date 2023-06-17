using View.Models.Entities;

namespace View.Models.Repositories;

public class ClassRepository : RepositoryBase<Class>
{
    public ClassRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}