using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.DataAccess.Abstract;
using DynamicFormDemo.DataAccess.Contexts;
using DynamicFormDemo.DataAccess.Repositories;
using DynamicFormDemo.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DynamicFormDemo.DataAccess.Concrete
{
    public class EfFormDal : EfRepository<Form> , IFormDal
    {
        private readonly FormDemoContext _context;
        public EfFormDal(FormDemoContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Form> FindWithUser()
        {
            using (_context)
            {
                return _context.Forms.Include(f => f.User).ToList().AsQueryable();
            }
        }

        public IIncludableQueryable<Form, ICollection<Field>?> FindWithFieldAndUser()
        {
            return _context.Forms.Include(x => x.Fields);
        }
    }
}
