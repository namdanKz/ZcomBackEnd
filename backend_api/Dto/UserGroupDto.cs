using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Dto
{
    public class UserGroupDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
    }
}