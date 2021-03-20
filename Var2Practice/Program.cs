using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var2Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите выражение: ");

            string arithmeticExpression = Console.ReadLine();

            CalculateClass calculateClass = new CalculateClass(arithmeticExpression);

            int Result = calculateClass.GetResult();

            Console.WriteLine("Результат выражения: {0}", Result);

            Console.ReadLine();
        }
    }
}
