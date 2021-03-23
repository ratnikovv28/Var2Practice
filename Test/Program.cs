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
                if (str[i] != '+' && str[i] != '-' && str[i] != '/' && str[i] != '*' && str[i] != '(' && str[i] != ')' &&
                    str[i] != ',' && str[i] != ' ' && !char.IsNumber(str[i])) throw new Exception("Некорректные данные"); // Проверка на корректность вводимых символов.

                if (str[i] == ' ') continue; // Проверка на наличие пробела, если есть, то в список символов пробел не идёт.

                if ((str[i] == '-' && i == 0) || (str[i] == '-' && str[i - 1] == '('))      // Проверка возможных вариантов ввода отрицательного числа:
                {                                                                           // 1)Если пользователь введёт - в самом начале, например: -5 + 10.
                    symbol += str[i];                                                       // 2)Если пользователь введёт отрицательное число в скобках, например: ... (-5 + 10).
                }

                else if (str[i] == '+' || str[i] == '-' || str[i] == '/' || str[i] == '*' || str[i] == '(' || str[i] == ')') // Проверка
                {
                    if (symbol != "") symbolsList.Add(symbol);

                    symbol = "";

                    if (i != 0 && str[i] == '(' && char.IsNumber(str[i - 1])) symbolsList.Add("*"); // Специальная проверка с добавлением умножения. Нужна для того, чтобы
                                                                                                                 // была возможность не писать знак умножения при умножении числа на скобку, например: 4(5+6). 

                    symbolsList.Add(str[i].ToString());

                    if (i != str.Length - 1 && str[i] == ')' && (str[i + 1] == '(' || char.IsNumber(str[i]))) symbolsList.Add("*"); // Специальная проверка с добавлением умножения. Нужна для того, чтобы
                }                                                                                                                                          // 1)была возможность не писать знак умножения при умножении скобки на число, например: 4(5+6)
                                                                                                                                                           // 2)была возможность не писать знак умножения при умножении двух скобок, например: (5+5)(5+6)

                else symbol += str[i];
            }
            if (str.Length == 1 || ((str[str.Length - 2] != ')' && str[str.Length - 1] != ')') || (str[str.Length - 1] != ')' && str[str.Length - 2] == ')'))) symbolsList.Add(symbol);

            symbolsList.Add("$"); //Доллар необходим, так как он сигнализирует алгоритму, что строка закончилась.

            Console.Read();
        }
    }
}
