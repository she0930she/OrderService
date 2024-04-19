using System.Linq.Expressions;
using ApplicationCore.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
{
    private readonly ProductDbContext _productDbContext;

    public BaseRepositoryAsync(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }


    public Task<int> InsertAsync(T entity)
    {
        _productDbContext.Set<T>().AddAsync(entity);
        return _productDbContext.SaveChangesAsync();
    }

    public Task<int> UpdateAsync(T entity)
    {
        _productDbContext.Entry(entity).State = EntityState.Modified;
        return _productDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _productDbContext.Remove(entity);
        return await _productDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _productDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var res = await _productDbContext.Set<T>().FindAsync(id);
        return res;
    }

    public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> filter)
    {
        return await _productDbContext.Set<T>().Where(filter).ToListAsync();
    }

    public async Task<T> FilterByModel(Expression<Func<T, bool>> filter)
    {
        return await _productDbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
    }


}