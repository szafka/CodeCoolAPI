namespace CodeCoolAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository Authors { get; set; }
        public IReviewRepository Reviews { get; set; }
        public IMaterialRepository Materials { get; set; }
        public IMaterialTypeRepository MaterialTypes { get; set; }
        public UnitOfWork(IAuthorRepository authors, IMaterialTypeRepository materialTypes, IMaterialRepository materials, IReviewRepository reviews)
        {
            Authors = authors;
            Reviews = reviews;
            Materials = materials;
            MaterialTypes = materialTypes;
        }
    }
}
