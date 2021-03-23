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
        private double Result;

        #region Стеки и таблица переходов

        private StackClass<string> T = new StackClass<string>(); //Для записи операций и скобок.

        private StackClass<double> E = new StackClass<double>(); //Для операндов.

        private byte[,] transitionTable = new byte[6, 7] //Таблица переходов.
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

        private double CalculateExpression(double firstNum, double secondNum, string operation)
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

        private byte GetFunctionNumberFromTransitionTable(string symbol)
        {
            byte index = 0;
            switch (symbol)
            {
                case "$": index = 0;
                    break;
                case "(": index = 1;
                    break;
                case "+": index = 2;
                    break;
                case "-": index = 3;
                    break;
                case "*": index = 4;
                    break;
                case "/": index = 5;
                    break;
                case ")": index = 6;
                    break;
            }

            return index;
        } 

        private List<string> ParsingString(string str) 
        {
            List<string> symbolsList = new List<string>();

            string symbol = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '+' && str[i] != '-' && str[i] != '/' && str[i] != '*' && str[i] != '(' && str[i] != ')' &&
                    str[i] != ',' && str[i] != ' ' && !char.IsNumber(str[i])) throw new Exception("Введены некорректные данные!"); // Проверка на корректность введеных символов.

                if (str[i] == ' ') continue; // Проверка на наличие пробела, если есть, то в список символов пробел не идёт.

                if ((str[i] == '-' && i == 0) || (str[i] == '-' && str[i - 1] == '('))      // Проверка возможных вариантов ввода отрицательного числа:
                {                                                                           // 1)Если пользователь введёт - в самом начале, например: -5 + 10.
                    symbol += str[i];                                                       // 2)Если пользователь введёт отрицательное число в скобках, например: ... (-5 + 10).
                }

                else if (!char.IsNumber(str[i]))
                {
                    if (symbol != "") symbolsList.Add(symbol);

                    symbol = "";

                    if (i != 0 && str[i] == '(' && char.IsNumber(str[i - 1])) symbolsList.Add("*"); // Специальная проверка с добавлением умножения. Нужна для того, чтобы
                                                                                                    // была возможность не писать знак умножения при умножении числа на скобку, например: 4(5+6). 
                    
                    symbolsList.Add(str[i].ToString());

                    if (i != str.Length - 1 && str[i] == ')' && (str[i + 1] == '(' || char.IsNumber(str[i]))) symbolsList.Add("*"); // Специальная проверка с добавлением умножения. Нужна для того, чтобы
                }                                                                                                                       // 1)была возможность не писать знак умножения при умножении скобки на число, например: (5+6)4
                                                                                                                                        // 2)была возможность не писать знак умножения при умножении двух скобок, например: (5+5)(5+6)
                else symbol += str[i];
            }
            if (str[str.Length - 1] != ')') symbolsList.Add(symbol);

            symbolsList.Add("$"); //Доллар необходим, так как он сигнализирует алгоритму, что строка закончилась.

            return symbolsList;
        } 

        private void ExecuteOperation(string symbol)
        {
            byte index1 = GetFunctionNumberFromTransitionTable(T.Peek());
            byte index2 = GetFunctionNumberFromTransitionTable(symbol);

            switch (transitionTable[index1, index2])
            {
                case 1: T.Push(symbol);
                    break;
                case 2:
                {
                    string operation = T.Peek();
                    double secondNum = E.Peek();
                    E.Pop();
                    double firstNum = E.Peek();
                    E.Pop();
                    double result = CalculateExpression(firstNum, secondNum, operation);
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
                    double secondNum = E.Peek();
                    E.Pop();
                    double firstNum = E.Peek();
                    E.Pop();
                    double result = CalculateExpression(firstNum, secondNum, operation);
                    E.Push(result);
                    T.Pop();
                    ExecuteOperation(symbol);
                }
                    break;
                case 5: throw new Exception("Возникла ошибка при выполнении алгоритма!");
                case 6: return;
            }

        } 

        #endregion

        public double GetResult(string arithmeticExpression)
        {
            T.Push("$");

            List<string> symbolsList = ParsingString(arithmeticExpression);

            foreach (string symbol in symbolsList)
            {
                if (symbol != "$" && symbol != "(" && symbol != "+" && symbol != "-" && symbol != "*" &&
                    symbol != "/" && symbol != ")") E.Push(double.Parse(symbol));
                else ExecuteOperation(symbol);
            }

            Result = E.Peek();
            return Result;
        } 
    }
}


