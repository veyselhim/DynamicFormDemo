using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormDemo.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> AsQueryable(bool tracking = true);
        IQueryable<T> FindWhere(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> FindWhereSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> FindByIdAsync(int id, bool tracking = true);
        IQueryable<T> FindAllById(int id, bool tracking = true);
        Task CreateAsync(T entity);
        Task RemoveAsync(int id);
        void Update(T entity);

        public DbSet<T> Table { get; }

    }
}
