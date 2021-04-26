using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class Operand
    {
        public List<string> Infix { get; set; }
        public List<string> Postfix { get; set; }
        public string Value { get; set; }
    }
}
