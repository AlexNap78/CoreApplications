using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCisalfa.Models
{
    public class ResponseResultModel
    {
        public OutcomeModel outcome { get; set; }

        public dynamic result { get; set; }
    }
}
