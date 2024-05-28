using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int? UserGroupId { get; set; } 
        public UserGroup? UserGroup { get; set; }
        public int QuestionIndex { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}