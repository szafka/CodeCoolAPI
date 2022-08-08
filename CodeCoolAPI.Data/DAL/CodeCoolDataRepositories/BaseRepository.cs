namespace CodeCoolAPI.Data.DAL.CodeCoolDataRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly API_Context _context;
        public BaseRepository(API_Context context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedElement = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedElement.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
