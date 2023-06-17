using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class TeacherCollectionService : ITeacherCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public TeacherCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(Teacher teacher)
    {
        _unitOfWork.TeacherRepository.Remove(teacher);
        _unitOfWork.SaveChanges();
    }

    public List<Teacher> GetAll()
    {
        return _unitOfWork.TeacherRepository.GetAll();
    }

    public Teacher? GetById(int id)
    {
        return _unitOfWork.TeacherRepository.GetById(id);
    }

    public void Insert(Teacher teacher)
    {
        _unitOfWork.TeacherRepository.Insert(teacher);
        _unitOfWork.SaveChanges();
    }

    public void Update(Teacher teacher)
    {
        _unitOfWork.TeacherRepository.Update(teacher);
        _unitOfWork.SaveChanges();
    }
}