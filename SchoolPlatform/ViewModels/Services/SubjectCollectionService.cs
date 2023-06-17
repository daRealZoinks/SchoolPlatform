using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class SubjectCollectionService : ISubjectCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public SubjectCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(Subject subject)
    {
        _unitOfWork.SubjectRepository.Remove(subject);
        _unitOfWork.SaveChanges();
    }

    public List<Subject> GetAll()
    {
        return _unitOfWork.SubjectRepository.GetAll();
    }

    public void Insert(Subject subject)
    {
        _unitOfWork.SubjectRepository.Insert(subject);
        _unitOfWork.SaveChanges();
    }

    public void Update(Subject subject)
    {
        _unitOfWork.SubjectRepository.Update(subject);
        _unitOfWork.SaveChanges();
    }
}