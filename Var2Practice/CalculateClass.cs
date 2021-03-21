using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice;

namespace Var2Practice
{
    //Класс разрабатывал Ратников Владимир
    public class CalculateClass
    {
        private string ArithmeticExpression;

        private int Result;

        public CalculateClass(string arithmeticExpression)
        {
            ArithmeticExpression = arithmeticExpression;
        }

        #region Стеки и таблица переходов

        private StackClass<string> T = new StackClass<string>(); //Для записи операций и скобок

        private StackClass<int> E = new StackClass<int>(); //Для операндов

        private byte[,] jumpTable = new byte[6, 7]
        {
            {6, 1, 1, 1, 1, 1, 5},
            {5, 1, 1, 1, 1, 1, 3},
            {4, 1, 2, 2, 1, 1, 4},
            {4, 1, 2, 2, 1, 1, 4},
            {4, 1, 4, 4, 2, 2, 4},
            {4, 1, 4, 4, 2, 2, 4}
        };

        #endregion

        #region Вспомогательные функции

        private int Calculate(int firstNum, int secondNum, string operation)
        {
            switch (operation)
            {
                case "+": return firstNum + secondNum;
                case "-": return firstNum - secondNum;
                case "/": return firstNum / secondNum;
                case "*": return firstNum * secondNum;
            }
            return 0;
        }

        private int GetFunctionFromTable(string symbol)
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

            string symbol = "";

            foreach (char a in str)
            {
                if (a == ' ') continue;
                else if (a == '+' || a == '-' || a == '/' || a == '*' || a == '(' || a == ')')
                {
                    if (symbol != "") symbolsList.Add(symbol);
                    symbol = "";
                    symbolsList.Add(a.ToString());
                }
                else
                {
                    symbol += a;
                }
            }
            if (str[str.Length - 2] != ')' && str[str.Length - 1] != ')' && (str[str.Length - 1] != ' ' || str[str.Length - 1] == ' ')) symbolsList.Add(symbol);
            symbolsList.Add("$");

            return symbolsList;
        }

        private void PerformOperation(string symbol)
        {
            switch (jumpTable[GetFunctionFromTable(T.Peek()), GetFunctionFromTable(symbol)])
            {
                case 1: T.Push(symbol);
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
                    T.Pop();
                    T.Push(symbol);
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
                    T.Pop();
                    PerformOperation(symbol);
                }
                    break;
                case 5: throw new Exception("Возникла ошибка!");
                case 6: return;
            }

        }

        #endregion

        public int GetResult()
        {
            T.Push("$");

            List<string> str = ReadString(ArithmeticExpression);

            for (int i = 0; i < str.Count; i++)
            {
                if (str[i] != "$" && str[i] != "(" && str[i] != "+" && str[i] != "-" && str[i] != "*" &&
                    str[i] != "/" && str[i] != ")") E.Push(int.Parse(str[i].ToString()));
                else PerformOperation(str[i]);
            }

            Result = E.Peek();
            return Result;
        }
    }
}


