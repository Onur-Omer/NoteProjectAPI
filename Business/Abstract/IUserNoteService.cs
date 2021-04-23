using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserNoteService
    {
        IDataResult<List<UserNote>> GetAll();
        IDataResult<List<UserNote>> GetAllByUserId(int userId);
        IDataResult<UserNote> GetById(int noteId);
        IResult Add(UserNote userNote);
        IResult Update(UserNote userNote);
        IResult Delete(UserNote userNote);
        // IResult AddTransactionalTest(Product product);
    }
}
