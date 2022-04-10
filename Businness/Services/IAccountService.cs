using Businness.Model;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public interface IAccountService
    {
        IDataResult<User> Login(LoginModel model);
        IDataResult<User> Register(UserRegisterModel userRegisterModel, string password);
        IResult UserExists(string email);
    }
}
