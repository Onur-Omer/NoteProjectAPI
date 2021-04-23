using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IGroupService
    {
        IResult Add(Group group);
        IDataResult<Group> GetByGroupId(int id);
        IResult AddUser(int groupId, string userMail);
    }
}
