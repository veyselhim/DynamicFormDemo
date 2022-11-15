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
    public class UserManager : IUserService
    {

        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal) { _userDal = userDal; }

        public IDataResult<IQueryable<User>> AsQueryable()
        {
            return new SuccessDataResult<IQueryable<User>>(_userDal.AsQueryable(false), "Kullanıcılar listelendi");
        }

        public IDataResult<IQueryable<User>> FindWhere(Expression<Func<User, bool>> filter, bool tracking = true)
        {
            return new SuccessDataResult<IQueryable<User>>(_userDal.FindWhere(x => x.UserName == "veysel", false));
        }

        public async Task<IDataResult<User>> FindWhereSingleAsync(Expression<Func<User, bool>> filter, bool tracking = true)
        {
            return new SuccessDataResult<User>(await _userDal.FindWhereSingleAsync(x => x.Id == 1),"Kullanıcı gösterildi");
        }

        public async Task<IDataResult<User>> FindByIdAsync(int id, bool tracking = true)
        {
            return new SuccessDataResult<User>(await _userDal.FindByIdAsync(id, false), "Kullanıcı gösterildi");
        }

        public async Task<IResult> CreateAsync(User entity)
        {
             await _userDal.CreateAsync(entity);
            return new SuccessResult("Kullanıcı oluşturuldu");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            await _userDal.RemoveAsync(id);
            return new SuccessResult("Kullanıcı silindi");
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult("Kullanıcı güncellendi");
        }
    }
}
