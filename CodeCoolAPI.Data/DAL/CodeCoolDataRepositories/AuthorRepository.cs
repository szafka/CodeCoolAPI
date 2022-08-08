namespace CodeCoolAPI.Data.DAL.CodeCoolDataRepositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly API_Context _context;
        public AuthorRepository(API_Context context) : base(context)
        {
            _context = context;
        }
        public async Task GetElementByIdAsync(int id) => await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);
    }
}
