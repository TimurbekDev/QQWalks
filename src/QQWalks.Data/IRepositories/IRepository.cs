using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Data.IRepositories;

public interface IRepository<T>
{
    public Task<T> CreateAsync(T entity);
    public Task<T> UpdateAsync(T entity); 
    public IQueryable<T> GetAllAsync();
    public Task<T> GetByIdAsync(Guid Id);
    public Task<bool> DeleteAsync(Guid Id);
}
