using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace DynamicFormDemo.Business.BusinessRepostiory
{
    public interface IBusinessService<T>
    {
        IDataResult<IQueryable<T>> AsQueryable();
        IDataResult<IQueryable<T>> FindWhere(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<IDataResult<T>> FindWhereSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<IDataResult<T>> FindByIdAsync(int id, bool tracking = true);
        Task<IResult> CreateAsync(T entity);
        Task<IResult> RemoveAsync(int id);
        IResult Update(T entity);
    }
}
