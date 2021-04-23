using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class GroupManager : IGroupService
    {
        IGroupDal _groupDal;
        private IUserService _userService;

        public GroupManager(IGroupDal groupDal, IUserService userService)
        {
            _groupDal = groupDal;
            _userService = userService;
        }

        [SecuredOperation("user,admin")]
        public IResult Add(Group group)
        {
            _groupDal.Add(group);
            return new SuccessResult(Messages.Success);
        }

        [SecuredOperation("user,admin")]
        public IDataResult<Group> GetByGroupId(int id)
        {
            return new SuccessDataResult<Group>(_groupDal.Get(g => g.GroupId == id));
        }

        [SecuredOperation("admin,user")]
        public IResult AddUser(int groupId, string userMail)
        {
            var result = GetByGroupId(groupId);
            if (result.Success)
            {
                var user = _userService.GetByMail(userMail);
                _userService.AddGroup(groupId, user.Data.UserId.ToString());
                return new SuccessResult();
            }
            
            return new ErrorResult(Messages.GroupNotFound);
        }
    }
}
