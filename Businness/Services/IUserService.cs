﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public interface IUserService
    {
        void Add(User user);
        User GetByEmail(string userName);
    }
}
