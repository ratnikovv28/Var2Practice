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
                if (str[i] != '+' && str[i] != '-' && str[i] != '/' && str[i] != '*' && str[i] != '(' && str[i] != ')'
                    && str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5' && str[i] != '6'
                    && str[i] != '7' && str[i] != '8' && str[i] != '9' && str[i] != '0' && str[i] != ',' && str[i] != ' ') throw new Exception("Некорректные данные"); //Проверка на корректные символы.

                if (str[i] == ' ') continue; //Проверка на наличие пробела, если есть, то в список символов пробел не идёт.


                if ((str[i] == '-' && i == 0) || (str[i] == '-' && str[i - 1] == '('))      // Проверка возможных вариантов ввода:
                {                                                                           // 1)Если пользователь введёт - в самом начале, например: -5 + 10.
                    symbol += str[i];                                                       // 2)Если пользователь введёт отрицательное число в скобках, например: ... (-5 + 10).
                }

                else if (str[i] == '+' || str[i] == '-' || str[i] == '/' || str[i] == '*' || str[i] == '(' || str[i] == ')')
                {
                    if (symbol != "") symbolsList.Add(symbol);

                    symbol = "";
                    
                    if(i != 0 && str[i] == '(' && (str[i - 1] == '1' || str[i - 1] == '2' || str[i - 1] == '3' || str[i - 1] == '4' || str[i - 1] == '5' || str[i - 1] == '6'
                                                    || str[i - 1] == '7' || str[i - 1] == '8' || str[i - 1] == '9' || str[i - 1] == '0')) symbolsList.Add("*");

                    symbolsList.Add(str[i].ToString());

                    if (i != str.Length - 1 && str[i] == ')' && (str[i + 1] == '(' || (str[i + 1] == '1' || str[i + 1] == '2' || str[i + 1] == '3' || str[i + 1] == '4' || str[i + 1] == '5' || str[i + 1] == '6'
                        || str[i + 1] == '7' || str[i + 1] == '8' || str[i + 1] == '9' || str[i + 1] == '0'))) symbolsList.Add("*");
                }

                else
                {
                    //if (i != str.Length - 1 && (str[i + 1] == '(' || str[i - 1] == ')')) symbolsList.Add("*"); //Условие, которое позволяет не писать знак умножения, например: 4(25+5).
                    symbol += str[i];
                }
            }
            if ((str[str.Length - 2] != ')' && str[str.Length - 1] != ')') || (str[str.Length - 1] != ')' && str[str.Length - 2] == ')')) symbolsList.Add(symbol);

            symbolsList.Add("$"); //Доллар необходим, так как он сигнализирует алгоритму, что строка закончилась.

            Console.Read();
        }
    }
}
