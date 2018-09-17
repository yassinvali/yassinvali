
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AttitudeAdmin.DBContext;

namespace AttitudeAdmin.DALRepository
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        readonly AttitudeDbContext _dbContext;

        public UserRepository()
        {
            _dbContext = new AttitudeDbContext();
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public IQueryable<T> Get()
        {
            return _dbSet;
        }

        public void Add(T model)
        {
            _dbSet.Add(model);
            SaveChange();
        }

        public void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            SaveChange();
        }

        public void Delete(T model)
        {
            _dbSet.Remove(model);
            SaveChange();
        }

        private void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}