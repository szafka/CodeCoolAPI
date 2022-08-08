namespace CodeCoolAPI.Data
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IMaterialRepository Materials { get; }
        IMaterialTypeRepository MaterialTypes { get; }
        IReviewRepository Reviews { get; }

    }
}
