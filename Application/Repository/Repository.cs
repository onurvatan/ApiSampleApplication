using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PeopleDbContext _peopleDbContext;

        public Repository(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public async Task<int> CreateAsync(T entity)
        {
            await _peopleDbContext.AddAsync(entity);

            return await _peopleDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _peopleDbContext.Entry(entity).State = EntityState.Deleted;

            return await _peopleDbContext.SaveChangesAsync();

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _peopleDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _peopleDbContext.Set<T>().FirstAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _peopleDbContext.Entry(entity).State = EntityState.Modified;

            return await _peopleDbContext.SaveChangesAsync();
        }
    }
}
