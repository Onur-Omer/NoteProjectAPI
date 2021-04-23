using System;
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
    public class GroupNoteManager : IGroupNoteService
    {
        IGroupNoteDal _groupNoteDal;

        public GroupNoteManager(IGroupNoteDal groupNoteDal)
        {
            _groupNoteDal = groupNoteDal;
        }
        
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(GroupNoteValidator))]
        [CacheRemoveAspect("IGroupNoteService.Get")]
        public IResult Add(GroupNote groupNote)
        {
            _groupNoteDal.Add(groupNote);
            return new SuccessResult(Messages.Success);
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IGroupNoteService.Get")]
        public IResult Delete(GroupNote groupNote)
        {
            _groupNoteDal.Delete(groupNote);
            return new SuccessResult(Messages.Success);
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<GroupNote>> GetAll()
        {
            return new SuccessDataResult<List<GroupNote>>(_groupNoteDal.GetAll(), Messages.NotesListed);
        }

        [SecuredOperation("admin,user")]
        [CacheAspect]
        public IDataResult<List<GroupNote>> GetAllByGroupId(int groupId)
        {
            return new SuccessDataResult<List<GroupNote>>(_groupNoteDal.GetAll(u => u.GroupId == groupId), Messages.NotesListed);
        }

        [SecuredOperation("admin,user")]
        [CacheAspect]
        public IDataResult<GroupNote> GetById(int noteId)
        {
            return new SuccessDataResult<GroupNote>(_groupNoteDal.Get(n => n.NoteId == noteId));
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(GroupNoteValidator))]
        [CacheRemoveAspect("IGroupNoteService.Get")]
        public IResult Update(GroupNote groupNote)
        {
            _groupNoteDal.Update(groupNote);
            return new SuccessResult(Messages.Success);
        }
    }
}
