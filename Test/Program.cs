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

            List<string> myList = new List<string>();

            int i = 0;

            string s = "";

            foreach (var a in str)
            {
                if(a == ' ') continue;
                else if (a == '+' || a == '-' || a == '/' || a == '*' || a == '(' || a == ')')
                {
                    if (s != "") myList.Add(s);
                    s = "";
                    myList.Add(a.ToString());
                }
                else
                {
                    s += a;
                }
            }
            if(str[str.Length - 2] != ')' && str[str.Length - 1] != ')' && (str[str.Length - 1] != ' ' || str[str.Length - 1] == ' ')) myList.Add(s);

            Console.Read();
        }
    }
}
