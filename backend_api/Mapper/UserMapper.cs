using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Dto;
using backend_api.Models;

namespace backend_api.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto{
                Id = userModel.Id,
                UserGroupId = userModel.UserGroupId,
                UserName = userModel.UserName,
                IsSubmitted = false
            };
        }
        public static User ToUserFromCreate(this CreateUserDto userDto)
        {
            return new User{
                UserGroupId = userDto.UserGroupId,
                UserName = userDto.UserName,
                IsSubmitted = false
            };
        }
    }
}