namespace _02.Data.Repositories
{
    using _01.Domain;
    using _01.Domain.Models;

    public class RepositoryFacade : IRepositoryFacade
    {
        private DataBaseConext conext;

        public RepositoryFacade()
        {
            this.conext = new DataBaseConext();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(this.conext);
        }
    }
}