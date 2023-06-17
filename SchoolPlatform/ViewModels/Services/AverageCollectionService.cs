using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class AverageCollectionService : IAverageCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public AverageCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(Average average)
    {
        _unitOfWork.AverageRepository.Remove(average);
        _unitOfWork.SaveChanges();
    }

    public List<Average> GetAll()
    {
        return _unitOfWork.AverageRepository.GetAll();
    }

    public void Insert(Average average)
    {
        _unitOfWork.AverageRepository.Insert(average);
        _unitOfWork.SaveChanges();
    }

    public void Update(Average average)
    {
        _unitOfWork.AverageRepository.Update(average);
        _unitOfWork.SaveChanges();
    }
}