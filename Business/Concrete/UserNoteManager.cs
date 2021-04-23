using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserNoteManager : IUserNoteService
    {
        IUserNoteDal _userNoteDal;

        public UserNoteManager(IUserNoteDal userNoteDal)
        {
            _userNoteDal = userNoteDal;
        }

        [SecuredOperation("user,admin")] 
        [ValidationAspect(typeof(UserNoteValidator))]
        [CacheRemoveAspect("IUserNoteService.Get")]
        public IResult Add(UserNote userNote)
        {
            _userNoteDal.Add(userNote);

            return new SuccessResult(Messages.Success);
        }

        [SecuredOperation("user,admin")]
        [CacheRemoveAspect("IUserNoteService.Get")]
        public IResult Delete(UserNote userNote)
        {
            _userNoteDal.Delete(userNote);

            return new SuccessResult(Messages.Success);
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<UserNote>> GetAll()
        {
            return new SuccessDataResult<List<UserNote>>(_userNoteDal.GetAll(), Messages.NotesListed);
        }

        [SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<List<UserNote>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<UserNote>>(_userNoteDal.GetAll(u => u.UserId == userId), Messages.NotesListed);
        }

        [SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<UserNote> GetById(int noteId)
        {
            return new SuccessDataResult<UserNote>(_userNoteDal.Get(n => n.NoteId == noteId));
        }

        [SecuredOperation("user,admin")]
        [ValidationAspect(typeof(UserNoteValidator))]
        [CacheRemoveAspect("IUserNoteService.Get")]
        public IResult Update(UserNote userNote)
        {
            _userNoteDal.Update(userNote);

            return new SuccessResult(Messages.Success);
        }
    }
}
