using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int GetResult() => Result;

        public void Calculate()
        {
            foreach (char symbol in ArithmeticExpression)
            {
                switch (symbol)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '6': return; break;
                }
            }
        }
    }
}
