namespace _02.Data.Repositories
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Threading.Tasks;
    using _01.Domain;

    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        private DbSet<T> entities;

        public Repository(DataBaseConext context)
        {
            this.Context = context;
        }

        protected DataBaseConext Context { get; private set; }

        private DbSet<T> Entities
        {
            get
            {
                if (this.entities == null)
                {
                    this.entities = this.Context.Set<T>();
                }

                return this.entities;
            }
        }

        public T Get(object id)
        {
            return this.Entities.Find(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await this.Entities.FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return this.Entities.AsQueryable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entities.Remove(entity);
        }
        
        public void Save()
        {
            this.ExecuteValidatedOperation(() =>
            {
                this.Context.SaveChanges();
            });
        }

        private void ExecuteValidatedOperation(Action operation)
        {
            try
            {
                operation();
            }
            catch (DbEntityValidationException ex)
            {
                throw new DataException(this.HandleException(ex), ex);
            }
        }

        private string HandleException(DbEntityValidationException ex)
        {
            var errorMessage = string.Empty;
            foreach (var validationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    errorMessage += Environment.NewLine
                                    + string.Format(
                                        "Property: {0} Error: {1}",
                                        validationError.PropertyName,
                                        validationError.ErrorMessage);
                }
            }

            return errorMessage;
        }
    }
}