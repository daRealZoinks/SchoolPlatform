using System.Collections.Generic;
using View.Models;
using View.Models.Entities;

namespace View.ViewModels.Services;

public class UserCollectionService : IUserCollectionService
{
    private readonly UnitOfWork _unitOfWork;

    public UserCollectionService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(User user)
    {
        _unitOfWork.UserRepository.Remove(user);
        _unitOfWork.SaveChanges();
    }

    public List<User> GetAll()
    {
        return _unitOfWork.UserRepository.GetAll();
    }

    public void Insert(User user)
    {
        _unitOfWork.UserRepository.Insert(user);
        _unitOfWork.SaveChanges();
    }

    public void Update(User user)
    {
        _unitOfWork.UserRepository.Update(user);
        _unitOfWork.SaveChanges();
    }
}