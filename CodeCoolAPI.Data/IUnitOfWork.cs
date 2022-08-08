namespace CodeCoolAPI.Data
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IMaterialRepository MaterialRepository { get; }
        IMaterialTypeRepository MaterialTypeRepository { get; }
        IReviewRepository ReviewRepository { get; }

    }
}
