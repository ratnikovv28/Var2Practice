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
        private string _arithmeticExpression;

        public string ArithmeticExpression
        {
            get => _arithmeticExpression;
            private set { _arithmeticExpression = value; }
        }

        private int Result { get; set; }

        public CalculateClass(string arithmeticExpression)
        {
            ArithmeticExpression = arithmeticExpression;
        }

        public StackClass<int> T = new StackClass<int>(); //Для записи операций и скобок

        public StackClass<int> E = new StackClass<int>(); //Для операндов

        private int[,] jumpTable = new int[6, 7]
        {
            {6, 1, 1, 1, 1, 1, 5},
            {5, 1, 1, 1, 1, 1, 3},
            {4, 1, 2, 2, 1, 1, 4},
            {4, 1, 2, 2, 1, 1, 4},
            {4, 1, 4, 4, 2, 2, 4},
            {4, 1, 4, 4, 2, 2, 4}
        };

        public int GetResult() => Result;


        //5 + 4 * 2
        public void Calculate()
        {
            foreach (char symbol in ArithmeticExpression)
            {
                if (symbol != '$' && symbol != '(' && symbol != '+' && symbol != '-' && symbol != '*' &&
                    symbol != '/' && symbol != ')') E.Push(int.Parse(symbol.ToString()));
                else
                {
                    int fisrtIndex = GetIndexFromTable(symbol);
                    int secondIndex = GetIndexFromTable(T.)
                    //switch (symbol)
                    //{
                    //    case '1':
                    //    {

                    //    }
                    //        break;
                    //    case '2':
                    //    {

                    //    }
                    //        break;
                    //    case '3':
                    //    {

                    //    }
                    //        break;
                    //    case '4':
                    //    {

                    //    }
                    //        break;
                    //    case '5':
                    //    {
                    //        Console.WriteLine("Произошла ошибка!");
                    //        return;
                    //    }
                    //    case '6': return;
                    //}
                }
            }
        }

        public static int GetIndexFromTable(char symbol)
        {
            int index = 0;
            switch (symbol)
            {
                case ' ':
                    index = 0;
                    break;
                case '(':
                    index = 1;
                    break;
                case '+':
                    index = 2;
                    break;
                case '-':
                    index = 3;
                    break;
                case '*':
                    index = 4;
                    break;
                case '/':
                    index = 5;
                    break;
                case ')':
                    index = 6;
                    break;
            }

            return index;
        }

        public string[] Test(string str)
        {
            string[] s = new string[6];

            foreach (var a in str)
            {
                if()
            }

            return s;
        }
    }
}


