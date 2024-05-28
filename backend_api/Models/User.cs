using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public int? UserGroupId { get; set; }
        public UserGroup? UserGroup { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsSubmitted {get;set;} = false; 
        public List<SelectedChoices> SelectedChoices { get; set; } = new List<SelectedChoices>();
    }
}