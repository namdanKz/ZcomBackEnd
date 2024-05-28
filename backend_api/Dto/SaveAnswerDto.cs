using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Dto
{
    public class SaveAnswerDto
    {
        public string userName {get;set;} = string.Empty;
        public List<int> answerId{get;set;} = [];
    }
}