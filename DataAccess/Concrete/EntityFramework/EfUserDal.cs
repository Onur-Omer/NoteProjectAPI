using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DbContextBase>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DbContextBase())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.UserId
                    select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
                return result.ToList();

            }
        }

        public IResult AddGroup(int groupId, string userId)
        {
            int userIdToInt = Int32.Parse(userId);
            var user = Get(u => u.UserId == userIdToInt);
            if (user.JoinedGroupIds == null)
            {
                user.JoinedGroupIds = groupId.ToString();
            }
            else
            {
                user.JoinedGroupIds = user.JoinedGroupIds + "," + groupId.ToString();
            }

            Update(user);

            return new SuccessResult();
            
        }
    }
}
