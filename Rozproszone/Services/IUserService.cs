﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rozproszone.Models;

namespace Rozproszone.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
