using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice;

namespace Var2Practice
{
    public class CalculateClass
    {
        private string ArithmeticExpression { get; set; }

        private int Result { get; set; }

        public CalculateClass(string arithmeticExpression)
        {
            ArithmeticExpression = arithmeticExpression;
        }

        private StackClass<string> T = new StackClass<string>(); //Для записи операций и скобок

        private StackClass<int> E = new StackClass<int>(); //Для операндов

        private int[,] jumpTable = new int[6, 7]
        {
            {6, 1, 1, 1, 1, 1, 5},
            {5, 1, 1, 1, 1, 1, 3},
            {4, 1, 2, 2, 1, 1, 4},
            {4, 1, 2, 2, 1, 1, 4},
            {4, 1, 4, 4, 2, 2, 4},
            {4, 1, 4, 4, 2, 2, 4}
        };

        private int Calculate(int firstNum, int secondNum, string operation)
        {
            switch (operation)
            {
                case "+": return  firstNum + secondNum;
                case "-": return firstNum - secondNum;
                case "/": return firstNum / secondNum;
                case "*": return firstNum * secondNum;
            }
            return 0;
        }

        public int GetResult()
        {
            T.Push("$");

            List<string> str = ReadString(ArithmeticExpression);

            for (int i = 0; i < str.Count; i++)
            {
                if (str[i] != "$" && str[i] != "(" && str[i] != "+" && str[i] != "-" && str[i] != "*" &&
                    str[i] != "/" && str[i] != ")" && str[i] != null)
                {
                    E.Push(int.Parse(str[i].ToString()));
                    if(T.IsEmpty) T.Push("$");
                }
                else
                {
                    switch (jumpTable[GetNumberFromTable(T.Peek()), GetNumberFromTable(str[i])])
                    {
                        case 1:
                        {
                            T.Pop();
                            T.Push(str[i]);
                        }
                            break;
                        case 2:
                        {
                            string operation = T.Peek();
                            int secondNum = E.Peek();
                            E.Pop();
                            int firstNum = E.Peek();
                            E.Pop();
                            int result = Calculate(firstNum, secondNum, operation);
                            E.Push(result);
                            T.Push(str[i]);
                        }
                            break;
                        case 3: T.Pop();
                            break;
                        case 4:
                        {
                            string operation = T.Peek();
                            int secondNum = E.Peek();
                            E.Pop();
                            int firstNum = E.Peek();
                            E.Pop();
                            int result = Calculate(firstNum, secondNum, operation);
                            E.Push(result);
                        } break;
                        case 5: Console.WriteLine("Возникла ошибка!");
                            break;
                        case 6: break;
                    }
                }
            }

            Result = E.Peek();
            return Result;
        }


        private int GetNumberFromTable(string symbol)
        {
            int index = 0;
            switch (symbol)
            {
                case "$":
                    index = 0;
                    break;
                case "(":
                    index = 1;
                    break;
                case "+":
                    index = 2;
                    break;
                case "-":
                    index = 3;
                    break;
                case "*":
                    index = 4;
                    break;
                case "/":
                    index = 5;
                    break;
                case ")":
                    index = 6;
                    break;
            }

            return index;
        }

        private List<string> ReadString(string str)
        {
            List<string> symbolsList = new List<string>(); //Подумать над названием переменной

            string number = "";

            foreach (var a in str)
            {
                if (a == '+' || a == '-' || a == '/' || a == '*' || a == '(' || a == ')')
                {
                    if (number != "") symbolsList.Add(number);
                    number = "";
                    symbolsList.Add(a.ToString());
                }
                else number += a;
            }
            if (str[str.Length - 1] != ')') symbolsList.Add(number);
            symbolsList.Add("$");

            return symbolsList;
        }
    }
}


