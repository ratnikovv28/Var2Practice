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

            List<string> symbolsList = new List<string>();

            string symbol = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ') continue; //Проверка на наличие пробела, если есть, то в список символов пробел не идёт.

                if ((str[i] == '-' && i == 0) || (str[i] == '-' && str[i - 1] == '('))      // Проверка возможных вариантов ввода:
                {                                                                           // 1)Если пользователь введёт - в самом начале, например: -5 + 10.
                    symbol += str[i];                                                       // 2)Если пользователь введёт отрицательное число в скобках, например: ... (-5 + 10).
                }

                else if (str[i] == '+' || str[i] == '-' || str[i] == '/' || str[i] == '*' || str[i] == '(' || str[i] == ')')
                {
                    if (symbol != "") symbolsList.Add(symbol);
                    symbol = "";
                    symbolsList.Add(str[i].ToString());
                }

                else symbol += str[i];
            }
            if (str[str.Length - 2] != ')' && str[str.Length - 1] != ')') symbolsList.Add(symbol);

            Console.Read();
        }
    }
}
