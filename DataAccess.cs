namespace Generics
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=employee.db");
        }
    }

    public interface IReadonlyRepository<out T>
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }

    public interface IRepository<T> : IReadonlyRepository<T>, IDisposable
    {
        void Add(T entity);
        void Delete(T entity);
        int Commit();
    }

    public class SqlRepository<T>: IRepository<T> where T: class, IEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _set;

        public SqlRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }


        public void Dispose() => _context.Dispose();


        public void Add(T entity)
        {
            if (entity.IsValid())
                _set.Add(entity);
        }

        public void Delete(T entity) => _set.Remove(entity);

        public T FindById(int id) => _set.Find(id);

        public IQueryable<T> FindAll() => _set;

        public int Commit() => _context.SaveChanges();

    }
}