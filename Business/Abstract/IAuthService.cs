using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> UserRegister(UserForRegisterDto userForRegisterDto);
        IDataResult<Group> GroupRegister(GroupForRegisterDto groupForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult ShareGroup(int groupId, string userMail);
        IDataResult<List<Group>> UserGroups(string userEmail);
    }
}
