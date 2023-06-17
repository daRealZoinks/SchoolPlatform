using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class SpecializationCollectionService : ISpecializationCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public SpecializationCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(Specialization specialization)
    {
        _unitOfWork.SpecializationRepository.Remove(specialization);
        _unitOfWork.SaveChanges();
    }

    public List<Specialization> GetAll()
    {
        return _unitOfWork.SpecializationRepository.GetAll();
    }

    public void Insert(Specialization specialization)
    {
        _unitOfWork.SpecializationRepository.Insert(specialization);
        _unitOfWork.SaveChanges();
    }

    public void Update(Specialization specialization)
    {
        _unitOfWork.SpecializationRepository.Update(specialization);
        _unitOfWork.SaveChanges();
    }
}