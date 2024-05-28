using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public int? UserGroupId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsSubmitted {get;set;} = false; 
    }
}