using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.Business.Abstract;
using DynamicFormDemo.Business.Concrete;
using DynamicFormDemo.DataAccess.Abstract;
using DynamicFormDemo.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicFormDemo.DataAccess
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IUserService, UserManager>();


            services.AddScoped<IFieldDal, EfFieldDal>();
            services.AddScoped<IFieldService, FieldManager>();


            services.AddScoped<IFormDal, EfFormDal>();
            services.AddScoped<IFormService, FormManager>();
        }
    }
}
