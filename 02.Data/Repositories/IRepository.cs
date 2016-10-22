namespace _02.Data.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using _01.Domain;
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(object id);

        Task<T> GetAsync(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll();

        void Save();
    }
}