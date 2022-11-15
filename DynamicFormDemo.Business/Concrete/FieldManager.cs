using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DynamicFormDemo.Business.Abstract;
using DynamicFormDemo.DataAccess.Abstract;
using DynamicFormDemo.Entity.Concrete;

namespace DynamicFormDemo.Business.Concrete
{
    public class FieldManager : IFieldService
    {
        private readonly IFieldDal _fieldDal;

        public FieldManager(IFieldDal fieldDal)
        {
            _fieldDal = fieldDal;
        }

        public IDataResult<IQueryable<Field>> AsQueryable()
        {
            return new SuccessDataResult<IQueryable<Field>>(_fieldDal.AsQueryable(false), "Kolonlar listelendi");
        }

        public IDataResult<IQueryable<Field>> FindWhere(Expression<Func<Field, bool>> filter, bool tracking = true)
        {
            return new SuccessDataResult<IQueryable<Field>>(_fieldDal.FindWhere(x => x.Name == "login", false));
        }

        public async Task<IDataResult<Field>> FindWhereSingleAsync(Expression<Func<Field, bool>> filter, bool tracking = true)
        {
            return new SuccessDataResult<Field>(await _fieldDal.FindWhereSingleAsync(x => x.Id == 1), "Kolon gösterildi");
        }

        public async Task<IDataResult<Field>> FindByIdAsync(int id, bool tracking = true)
        {
            return new SuccessDataResult<Field>(await _fieldDal.FindByIdAsync(id, false), "Kolon gösterildi");
        }

        public async Task<IResult> CreateAsync(Field entity)
        {
            await _fieldDal.CreateAsync(entity);
            return new SuccessResult("Kolon oluşturuldu");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            await _fieldDal.RemoveAsync(id);
            return new SuccessResult("Kolon silindi");
        }

        public IResult Update(Field entity)
        {
            _fieldDal.Update(entity);
            return new SuccessResult("Kolon güncellendi");
        }

        public IQueryable<Field> FindByFormId(int id)
        {
          return _fieldDal.FindWhere(x=>x.FormId==id);
        }
    }
}
