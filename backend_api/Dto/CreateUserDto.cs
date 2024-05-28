using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Dto
{
    public class CreateUserDto
    {
        public int? UserGroupId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}