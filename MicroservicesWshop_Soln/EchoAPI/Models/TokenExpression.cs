using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoAPI.Models
{
    public class TokenExpression
    {
        public string Value { get; set; }
        public List<string> Tokens { get; set; }
    }
}
