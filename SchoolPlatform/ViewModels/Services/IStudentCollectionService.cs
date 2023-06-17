using View.Models.Entities;

namespace View.ViewModels.Services;

public interface IStudentCollectionService : ICollectionService<Student>
{
    Student? GetById(int id);
}