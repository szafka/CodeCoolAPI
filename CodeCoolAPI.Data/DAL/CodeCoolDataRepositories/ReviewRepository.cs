namespace CodeCoolAPI.Data.DAL.CodeCoolDataRepositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly API_Context _context;

        public ReviewRepository(API_Context context) : base(context)
        {
            _context = context;
        }
        public async Task GetElementByIdAsync(int id) => await _context.Reviews.FirstOrDefaultAsync(a => a.ReviewId == id);
    }
}
