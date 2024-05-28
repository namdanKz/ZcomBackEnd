using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Dto;
using backend_api.Models;

namespace backend_api.Mapper
{
    public static class UserGroupMapper
    {
        public static UserGroupDto ToUserGroupDto(this UserGroup userGroupModel)
        {
            return new UserGroupDto{
                Id = userGroupModel.Id,
                GroupName = userGroupModel.GroupName
            };
        }

    }
}