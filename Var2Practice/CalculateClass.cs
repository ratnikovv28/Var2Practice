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
            private set
            {
                _arithmeticExpression = value;
            }
        }

        private int Result { get; set; }
        public CalculateClass(string arithmeticExpression)
        {
            ArithmeticExpression = arithmeticExpression;
        }

        public StackClass<int> T = new StackClass<int>(); //Для записи операций и скобок

        public StackClass<int> E = new StackClass<int>(); //Для операндов

        public int GetResult() => Result;

        public void Calculate()
        {
            foreach (char symbol in ArithmeticExpression)
            {
                if (symbol != '$' && symbol != '(' && symbol != '+' && symbol != '-' && symbol != '*' &&
                    symbol != '/' && symbol != ')') E.Push(int.Parse(symbol.ToString()));
                else
                {


                    switch (symbol)
                    {
                        case '1':
                        {

                        }
                            break;
                        case '2':
                        {

                        }
                            break;
                        case '3':
                        {

                        }
                            break;
                        case '4':
                        {

                        }
                            break;
                        case '5':
                        {
                            Console.WriteLine("Произошла ошибка!");
                            return;
                        }
                        case '6': return;
                    }
                }
            }
        }
    }
}
