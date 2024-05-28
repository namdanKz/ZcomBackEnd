using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Dto
{
    public class SummaryDto
    {
        public string UserName { get; set; } = string.Empty;
        public int Score {get;set;}
        public int Rank {get;set;}
    }
}