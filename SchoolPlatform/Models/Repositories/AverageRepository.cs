using View.Models.Entities;

namespace View.Models.Repositories;

public class AverageRepository : RepositoryBase<Average>
{
    public AverageRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}