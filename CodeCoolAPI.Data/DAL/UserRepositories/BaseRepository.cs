using CodeCoolAPI.Data.DAL.UserRepositories.Interfaces;

namespace CodeCoolAPI.Data.DAL.UserRepositories
{
    public class BaseRepository<T> : IBaseUserRepository<T> where T : class
    {
    }
}
