using Microsoft.EntityFrameworkCore;
using QQWalks.Data.DbContexts;
using QQWalks.Data.IRepositories;
using QQWalks.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Data.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly QQWalksDbContext context;
    private readonly DbSet<T> set;

    public Repository(QQWalksDbContext context)
    {
        this.context = context;
        this.set = this.context.Set<T>();
    }
    public async Task<T> CreateAsync(T entity)
    {
        var model = await this.set.AddAsync(entity);
        await this.context.SaveChangesAsync();

        return model.Entity;
    }

    public async Task<bool> DeleteAsync(Guid Id)
    {
        var entity = await this.set.FirstOrDefaultAsync(set => set.Id == Id);
        this.set.Remove(entity);
        await this.context.SaveChangesAsync();

        return true;
    }

    public IQueryable<T> GetAllAsync()
    {
        return this.set;
    }

    public async Task<T> GetByIdAsync(Guid Id)
    {
        var entity = await this.set.FirstOrDefaultAsync(e=>e.Id == Id);

        return entity;
    }
    public async Task<T> UpdateAsync(T entity)
    {
        var model = this.set.Update(entity);
        await this.context.SaveChangesAsync();

        return model.Entity;
    }
}
