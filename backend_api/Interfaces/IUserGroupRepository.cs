using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Models;

namespace backend_api.Interfaces
{
    public interface IUserGroupRepository
    {
        Task<List<UserGroup>> GetAll();

        
    }
}