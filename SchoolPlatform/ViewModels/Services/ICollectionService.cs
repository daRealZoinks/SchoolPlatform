using System.Collections.Generic;
using View.Models.Entities;

namespace View.ViewModels.Services;

public interface ICollectionService<T> where T : BaseEntity
{
    void Insert(T entity);
    List<T> GetAll();
    void Delete(T entity);
    void Update(T entity);
}