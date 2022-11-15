using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.Business.BusinessRepostiory;
using DynamicFormDemo.Entity.Concrete;

namespace DynamicFormDemo.Business.Abstract
{
    public interface IUserService : IBusinessService<User>
    {
    }
}
