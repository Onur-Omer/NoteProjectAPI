using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{
    public interface IUserDal :IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        IResult AddGroup(int groupId,string userId);
    }
}
