using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class ClassCollectionService : IClassCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public ClassCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(Class classEntity)
    {
        _unitOfWork.ClassRepository.Remove(classEntity);
        _unitOfWork.SaveChanges();
    }

    public List<Class> GetAll()
    {
        return _unitOfWork.ClassRepository.GetAll();
    }

    public void Insert(Class classEntity)
    {
        _unitOfWork.ClassRepository.Insert(classEntity);
        _unitOfWork.SaveChanges();
    }

    public void Update(Class classEntity)
    {
        _unitOfWork.ClassRepository.Update(classEntity);
        _unitOfWork.SaveChanges();
    }
}