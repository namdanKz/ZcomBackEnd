using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class SelectedChoices
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
        public int? AnswerId { get; set; }
        public Answer? Answer { get; set; }


    }
}