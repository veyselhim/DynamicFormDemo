using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.DataAccess.Contexts;
using DynamicFormDemo.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DynamicFormDemo.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly FormDemoContext _context;
        public EfRepository(FormDemoContext context) { _context = context; }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> AsQueryable(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> FindWhere(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.Where(filter);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> FindWhereSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> FindByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public IQueryable<T> FindAllById(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();

            return query.Where(data => data.Id == id);

        }

        public async Task CreateAsync(T entity)
        {
            var entityEntry = await Table.AddAsync(entity);
            entityEntry.State = EntityState.Added;
            await _context.SaveChangesAsync();

        }

        public async Task RemoveAsync(int id)
        {
            var model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            var entityEntry = Table.Remove(model);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            entityEntry.State = EntityState.Modified;

            _context.SaveChanges();
        }

    }
}
