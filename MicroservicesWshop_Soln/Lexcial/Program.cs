using System;
using System.Collections;
using System.Collections.Generic;

namespace Lexcial
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            List<string> tokens = new List<string>();
            List<string> postfix = new List<string>();

            string infix = "1 * (12 - (30 / 4))";

            // tokenize
            string val = "";
            for (int i=0; i<infix.Length; i++)
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

            // convert to postfix            
            for (int i=0; i<tokens.Count; i++)
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
                else if (elem == "*" || elem == "/")
                {
                    if (stack.Count > 0)
                    {
                        string peek = stack.Peek();

                        if (peek == "*" || peek == "/")
                            postfix.Add(stack.Pop());
                    }

                    stack.Push(elem);
                }
                else if (elem == "+" || elem == "-")
                    stack.Push(elem);
                else
                    postfix.Add(elem);
            }

            while (stack.Count > 0)
                postfix.Add(stack.Pop());

            Console.WriteLine("Infix: " + infix);

            string s = "";
            foreach (var item in postfix)
                s += item + ' ';
            Console.WriteLine("Postfix: " + s);

            Console.ReadLine();


            Stack<double> stack2 = new Stack<double>();

            for (int i = 0; i < postfix.Count; i++)
            {
                string elem = postfix[i];

                if (elem == "*" || elem == "/" || elem == "+" || elem == "-")
                {
                    double rhs = stack2.Pop();
                    double lhs = stack2.Pop();

                    if (elem == "*")
                        stack2.Push(lhs * rhs);
                    else if (elem == "/")
                        stack2.Push(lhs / rhs);
                    else if (elem == "+")
                        stack2.Push(lhs + rhs);
                    else if (elem == "-")
                        stack2.Push(lhs - rhs);
                }
                else
                    stack2.Push(double.Parse(elem));
            }

            Console.WriteLine("Stack Size: " + stack2.Count);
            Console.WriteLine("Value: " + stack2.Pop());
            Console.ReadLine();
        }
    }
}
