using View.Models.Entities;

namespace View.Models.Repositories;

public class SpecializationRepository : RepositoryBase<Specialization>
{
    public SpecializationRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}