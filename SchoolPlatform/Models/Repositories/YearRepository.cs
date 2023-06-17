using View.Models.Entities;

namespace View.Models.Repositories;

public class YearRepository : RepositoryBase<Year>
{
    public YearRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}