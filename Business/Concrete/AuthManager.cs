using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimService _userOperationClaimService;
        private IGroupService _groupService;
        private IHttpContextAccessor _httpContextAccessor;


        public AuthManager(IUserService userService, ITokenHelper tokenHelper,
            IUserOperationClaimService userOperationClaimService, IGroupService groupService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
            _groupService = groupService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDataResult<User> UserRegister(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            //Default claim type =>user
            var userOperationClaim = new UserOperationClaim
            {
                UserId = user.UserId,
                OperationClaimId = 2
            };
            _userOperationClaimService.Add(userOperationClaim);
            return new SuccessDataResult<User>(user,Messages.SuccessSignIn);
        }

        [SecuredOperation("user,admin")]
        public IDataResult<Group> GroupRegister(GroupForRegisterDto groupForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(groupForRegisterDto.Password, out passwordHash, out passwordSalt);
            var currentIdentityName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var group = new Group
            {
                GroupName = groupForRegisterDto.GroupName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _groupService.Add(group);
            _userService.AddGroup(group.GroupId, currentIdentityName);
            return new SuccessDataResult<Group>(group,Messages.SuccessSignIn);
        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck,Messages.SuccessLognIn);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAvailable);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.TokenOk);
        }

        public IResult ShareGroup(int groupId, string userMail)
        {
            _groupService.AddUser(groupId, userMail);
            return new SuccessResult();
        }
    }
}
