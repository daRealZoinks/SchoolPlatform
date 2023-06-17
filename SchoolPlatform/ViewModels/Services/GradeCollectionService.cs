using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class GradeCollectionService : IGradeCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public GradeCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(Grade grade)
    {
        _unitOfWork.GradeRepository.Remove(grade);
        _unitOfWork.SaveChanges();
    }

    public List<Grade> GetAll()
    {
        return _unitOfWork.GradeRepository.GetAll();
    }

    public void Insert(Grade grade)
    {
        _unitOfWork.GradeRepository.Insert(grade);
        _unitOfWork.SaveChanges();
    }

    public void Update(Grade grade)
    {
        _unitOfWork.GradeRepository.Update(grade);
        _unitOfWork.SaveChanges();
    }
}