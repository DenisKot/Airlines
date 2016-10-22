namespace _02.Data.Repositories
{
    using _01.Domain;

    public interface IRepositoryFacade
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}