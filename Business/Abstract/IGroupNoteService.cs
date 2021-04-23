using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGroupNoteService
    {
        IDataResult<List<GroupNote>> GetAll();
        IDataResult<List<GroupNote>> GetAllByGroupId(int groupId);
        IDataResult<GroupNote> GetById(int noteId);
        IResult Add(GroupNote groupNote);
        IResult Update(GroupNote groupNote);
        IResult Delete(GroupNote groupNote);
        // IResult AddTransactionalTest(Product product);
    }
}
