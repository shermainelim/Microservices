using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenAPI.Services
{
    public class Tokenizer
    {
        public List<string> Tokenize(string infix)
        {
            List<string> tokens = new List<string>();
            
            string val = "";
            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];

                if (ch == '(' || ch == ')' ||
                    ch == '*' || ch == '/' ||
                    ch == '+' || ch == '-' ||
                    ch == ' ')
                {
                    if (val.Length != 0)
                    {
                        tokens.Add(val);
                        val = "";
                    }

                    if (ch != ' ')
                        tokens.Add(ch.ToString());
                }
                else
                    val += ch;
            }

            if (val.Length != 0)
                tokens.Add(val);

            return tokens;
        }
    }
}
