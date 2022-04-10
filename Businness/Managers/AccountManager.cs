using Businness.Constants;
using Businness.Model;
using Businness.Services;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Managers
{
    public class AccountManager : IAccountService
    {
        IUserService _userService;  
        public AccountManager(IUserService userService)
        {
            _userService = userService;  
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
        public IDataResult<User> Register(UserRegisterModel userRegisterModel, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userRegisterModel.Email,
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(LoginModel model)
        {
            var userToCheck = _userService.GetByEmail(model.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserLoginError);
            }

            if (!HashingHelper.VerifyPasswordHash(model.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.UserLoginError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.UserLoginSuccess);
        }
         
    }
}
