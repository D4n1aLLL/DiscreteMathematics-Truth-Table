using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truth_Table_Generator
{
    class Algorithm
    {
        static Stack<char> symStack;
        static Stack<char> postFix;
        private string expr;
        public Algorithm(string _expr)
        {
            expr = _expr;
            symStack = new Stack<char>();
            postFix = new Stack<char>();
        }
        public char[] Converter()
        {
                char[] result;
                expr += "$";
                symStack.Push('(');
                for (int i = 0; i < expr.Length; i++)
                {

                    if (expr[i] == '$')
                    {
                        while (symStack.Count!=0)
                        {
                            postFix.Push(symStack.Pop());
                        }
                        break;
                    }
                    if (expr[i] == ')')
                    {
                        while (symStack.Peek()!='(')
                        {
                            postFix.Push(symStack.Pop());
                        }
                        symStack.Pop();
                    }
                    if (char.IsLetter(expr[i]))
                    {
                        postFix.Push(expr[i]);
                    }
                    else
                    {
                    symStack.Push(expr[i]);
                    }
                }
                result = postFix.ToArray();
                return result;
        }
        /*
        void precidenceChecker(char ch)
        {
            if (symStack.Peek() == '(')
            {
                symStack.Push(ch);
            }
            else if (symStack.Peek() == '+' & ch == '+')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '-' & ch == '-')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '*' & ch == '*')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '/' & ch == '/')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '+' & ch == '-')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '*' & ch == '+')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '*' & ch == '-')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '*' & ch == '/')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '/' & ch == '+')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '/' & ch == '-')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == '/' & ch == '*')
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (symStack.Peek() == ch)
            {
                char tmp = symStack.Peek();
                symStack.Pop();
                symStack.Push(ch);
                postFix.Push(tmp);
            }
            else if (ch==')')
            {
                while(symStack.Peek()!='(')
                {
                    postFix.Push(symStack.Pop());
                }
                symStack.Pop();
            }
        }*/
    }
}
