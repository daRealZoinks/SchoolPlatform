using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class AbsenceCollectionService : IAbsenceCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public AbsenceCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(Absence absence)
    {
        _unitOfWork.AbsenceRepository.Remove(absence);
        _unitOfWork.SaveChanges();
    }

    public List<Absence> GetAll()
    {
        return _unitOfWork.AbsenceRepository.GetAll();
    }

    public void Insert(Absence absence)
    {
        _unitOfWork.AbsenceRepository.Insert(absence);
        _unitOfWork.SaveChanges();
    }

    public void Update(Absence absence)
    {
        _unitOfWork.AbsenceRepository.Update(absence);
        _unitOfWork.SaveChanges();
    }
}