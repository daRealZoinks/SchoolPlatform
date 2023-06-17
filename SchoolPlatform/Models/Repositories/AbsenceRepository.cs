using View.Models.Entities;

namespace View.Models.Repositories;

public class AbsenceRepository : RepositoryBase<Absence>
{
    public AbsenceRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}