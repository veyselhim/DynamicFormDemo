using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.DataAccess.Abstract;
using DynamicFormDemo.DataAccess.Contexts;
using DynamicFormDemo.DataAccess.Repositories;
using DynamicFormDemo.Entity.Concrete;

namespace DynamicFormDemo.DataAccess.Concrete
{
    public class EfFieldDal : EfRepository<Field> , IFieldDal
    {
        public EfFieldDal(FormDemoContext context) : base(context)
        {
        }
    }
}
