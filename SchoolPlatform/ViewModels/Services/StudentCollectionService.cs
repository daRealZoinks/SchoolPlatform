using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class StudentCollectionService : IStudentCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public StudentCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<Student> GetAll()
    {
        return _unitOfWork.StudentsRepository.GetAll();
    }

    public Student? GetById(int id)
    {
        return _unitOfWork.StudentsRepository.GetById(id);
    }

    public void Delete(Student student)
    {
        _unitOfWork.StudentsRepository.Remove(student);
        _unitOfWork.SaveChanges();
    }

    public void Update(Student student)
    {
        _unitOfWork.StudentsRepository.Update(student);
        _unitOfWork.SaveChanges();
    }

    public void Insert(Student student)
    {
        _unitOfWork.StudentsRepository.Insert(student);
        _unitOfWork.SaveChanges();
    }
}