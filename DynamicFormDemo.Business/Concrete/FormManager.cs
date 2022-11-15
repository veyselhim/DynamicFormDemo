using Core.Utilities.Results;
using DynamicFormDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.Business.Abstract;
using DynamicFormDemo.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Query;

namespace DynamicFormDemo.Business.Concrete
{
    public class FormManager : IFormService
    {
        private readonly IFormDal _formDal;

        public FormManager(IFormDal formDal)
        {
            _formDal = formDal;
        }

        public IDataResult<IQueryable<Form>> AsQueryable()
        {
            return new SuccessDataResult<IQueryable<Form>>(_formDal.AsQueryable(false), "Formlar listelendi");
        }

        public IDataResult<IQueryable<Form>> FindWhere(Expression<Func<Form, bool>> filter, bool tracking = true)
        {
            return new SuccessDataResult<IQueryable<Form>>(_formDal.FindWhere(x => x.Name == "login", false));
        }

        public async Task<IDataResult<Form>> FindWhereSingleAsync(Expression<Func<Form, bool>> filter, bool tracking = true)
        {
            return new SuccessDataResult<Form>(await _formDal.FindWhereSingleAsync(x => x.Id == 1), "Form gösterildi");
        }

        public async Task<IDataResult<Form>> FindByIdAsync(int id, bool tracking = true)
        {
            return new SuccessDataResult<Form>(await _formDal.FindByIdAsync(id, false), "Form gösterildi");
        }

        public async Task<IResult> CreateAsync(Form entity)
        {
            await _formDal.CreateAsync(entity);
            return new SuccessResult("Form oluşturuldu");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            await _formDal.RemoveAsync(id);
            return new SuccessResult("Form silindi");
        }

        public IResult Update(Form entity)
        {
            _formDal.Update(entity);
            return new SuccessResult("Form güncellendi");
        }

        public IDataResult<IQueryable<Form>> FindWithUser()
        {
            return new SuccessDataResult<IQueryable<Form>>(_formDal.FindWithUser());
        }

        public IDataResult<IIncludableQueryable<Form, ICollection<Field>?>> FindWithFieldsAndUser()
        {
            return new SuccessDataResult<IIncludableQueryable<Form, ICollection<Field>?>>(_formDal.FindWithFieldAndUser());
        }
    }
}
