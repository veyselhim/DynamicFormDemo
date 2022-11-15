using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.DataAccess.Repositories;
using DynamicFormDemo.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Query;

namespace DynamicFormDemo.DataAccess.Abstract
{
    public interface IFormDal : IRepository<Form>
    {
        IQueryable<Form> FindWithUser();
        IIncludableQueryable<Form, ICollection<Field>?> FindWithFieldAndUser();
    }
}
