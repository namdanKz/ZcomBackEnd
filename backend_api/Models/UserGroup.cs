using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<User> Users { get; set; } = new List<User>();
    }
}