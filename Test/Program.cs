using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            string[] s = new string[6];

            int i = 0;

            foreach (var a in str)
            {
                s[i] += a;
                if (a == '$' || a == '(' || a == '+' || a == '-' || a == '*' ||
                   a == '/' || a == ')')
                {
                    i++;
                }

                //    if (a != '$' && a != '(' && a != '+' && a != '-' && a != '*' &&
                //        a != '/' && a != ')')
                //    {
                //        s[i] += a;
                //    }
                //    else
                //    {
                //        i++;
                //        s[i] += a;
                //        i++;
                //    }
            }

                
            Console.Read();
        }
    }
}
