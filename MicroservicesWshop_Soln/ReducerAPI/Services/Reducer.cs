using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReducerAPI.Services
{
    public class Reducer
    {
        public double ReducePostfix(List<string> postfix)
        {
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < postfix.Count; i++)
            {
                string elem = postfix[i];

                if (elem == "*" || elem == "/" || 
                    elem == "+" || elem == "-")
                {
                    double rhs = stack.Pop();
                    double lhs = stack.Pop();

                    if (elem == "*")
                        stack.Push(lhs * rhs);
                    else if (elem == "/")
                        stack.Push(lhs / rhs);
                    else if (elem == "+")
                        stack.Push(lhs + rhs);
                    else if (elem == "-")
                        stack.Push(lhs - rhs);
                }
                else
                    stack.Push(double.Parse(elem));
            }

            return stack.Pop();
        }
    }
}
