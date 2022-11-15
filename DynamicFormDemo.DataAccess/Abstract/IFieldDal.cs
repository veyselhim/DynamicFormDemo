using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.DataAccess.Repositories;
using DynamicFormDemo.Entity.Concrete;

namespace DynamicFormDemo.DataAccess.Abstract
{
    public interface IFieldDal : IRepository<Field>
    {
    }
}
