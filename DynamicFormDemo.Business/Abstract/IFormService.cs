using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DynamicFormDemo.Business.BusinessRepostiory;
using DynamicFormDemo.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Query;

namespace DynamicFormDemo.Business.Abstract
{
    public interface IFormService : IBusinessService<Form>
    {
        IDataResult<IQueryable<Form>> FindWithUser();
        IDataResult<IIncludableQueryable<Form, ICollection<Field>?>> FindWithFieldsAndUser();
    }
}
