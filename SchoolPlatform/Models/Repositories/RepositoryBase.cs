using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using View.Models.Entities;

namespace View.Models.Repositories;

public class RepositoryBase<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    protected RepositoryBase(DbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public T? GetById(int id)
    {
        return _dbSet.FirstOrDefault(x => x.Id == id);
    }

    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}