using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class SubjectClassCollectionService : ISubjectClassCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public SubjectClassCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(SubjectClass subjectClass)
    {
        _unitOfWork.SubjectClassRepository.Remove(subjectClass);
        _unitOfWork.SaveChanges();
    }

    public List<SubjectClass> GetAll()
    {
        return _unitOfWork.SubjectClassRepository.GetAll();
    }

    public void Insert(SubjectClass subjectClass)
    {
        _unitOfWork.SubjectClassRepository.Insert(subjectClass);
        _unitOfWork.SaveChanges();
    }

    public void Update(SubjectClass subjectClass)
    {
        _unitOfWork.SubjectClassRepository.Update(subjectClass);
        _unitOfWork.SaveChanges();
    }
}