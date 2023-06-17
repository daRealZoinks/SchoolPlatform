using View.Models.Entities;

namespace View.ViewModels.Services;

public interface ITeacherCollectionService : ICollectionService<Teacher>
{
    Teacher? GetById(int id);
}