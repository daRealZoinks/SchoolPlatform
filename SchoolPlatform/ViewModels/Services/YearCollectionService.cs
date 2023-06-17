using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class YearCollectionService : IYearCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public YearCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(Year year)
    {
        _unitOfWork.YearRepository.Remove(year);
        _unitOfWork.SaveChanges();
    }

    public List<Year> GetAll()
    {
        return _unitOfWork.YearRepository.GetAll();
    }

    public void Insert(Year year)
    {
        _unitOfWork.YearRepository.Insert(year);
        _unitOfWork.SaveChanges();
    }

    public void Update(Year year)
    {
        _unitOfWork.YearRepository.Update(year);
        _unitOfWork.SaveChanges();
    }
}