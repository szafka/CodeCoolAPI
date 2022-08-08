namespace CodeCoolAPI.Data.DAL.CodeCoolDataRepositories
{
    public class MaterialTypeRepository : BaseRepository<MaterialType>, IMaterialTypeRepository
    {
        private readonly API_Context _context;

        public MaterialTypeRepository(API_Context context) : base(context)
        {
            _context = context;
        }
        public async Task GetElementByIdAsync(int id) => await _context.MaterialTypes.FirstOrDefaultAsync(a => a.TypeId == id);
    }
}
