using View.Models.Entities;

namespace View.Models.Repositories;

public class UserRepository : RepositoryBase<User>
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}