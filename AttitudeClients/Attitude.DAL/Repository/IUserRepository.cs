using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeClient.DALRepository
{
    public interface IUserRepository<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        IQueryable<T> Get();
        void Add(T model);
        void Update(T model);
        void Delete(T model);
    }
}
