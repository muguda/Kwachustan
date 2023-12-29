namespace TaxCalculator.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TId>
    {
        Task<TEntity> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TId id);
    }
}
