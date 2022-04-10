using Businness.Services;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Managers
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal=userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmail(string userName)
        {
            return _userDal.Get(u=>u.Email == userName);
        }
    }
}
