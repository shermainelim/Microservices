using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformAPI.Services
{
    public class Transformer
    {
        public List<string> InfixToPostfix(List<string> infix)
        {
            Stack<string> stack = new Stack<string>();
            List<string> postfix = new List<string>();

            List<string> tokens = infix;

            for (int i = 0; i < tokens.Count; i++)
            {
                string elem = tokens[i];

                if (elem == "(")
                    stack.Push(elem);
                else if (elem == ")")
                {
                    string op;
                    while ((op = stack.Pop()) != "(")
                        postfix.Add(op);
                }
                else if (elem == "*" || elem == "/" ||
                    elem == "+" || elem == "-")
                {
                    while (stack.Count > 0)
                    {
                        string peek = stack.Peek();

                        if (Precedence(peek) >= Precedence(elem))
                            postfix.Add(stack.Pop());
                        else
                            break;
                    }

                    stack.Push(elem);
                }
                else
                    postfix.Add(elem);
            }

            while (stack.Count > 0)
                postfix.Add(stack.Pop());

            return postfix;
        }

        protected int Precedence(string elem)
        {
            if (elem == "(" || elem == ")")
                return 1;
            if (elem == "+" || elem == "-")
                return 2;
            if (elem == "*" || elem == "/")
                return 3;

            return 0;
        }
    }
}
