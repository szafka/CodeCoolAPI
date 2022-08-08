namespace CodeCoolAPI.Data.DAL.CodeCoolDataRepositories
{
    public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
    {
        private readonly API_Context _context;

        public MaterialRepository(API_Context context) : base(context)
        {
            _context = context;
        }
        public async Task GetElementByIdAsync(int id) => await _context.Materials.FirstOrDefaultAsync(a => a.MaterialId == id);
    }
}
