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

            CalculateClass calculateClass = new CalculateClass();

            try
            {
                double Result = calculateClass.GetResult(arithmeticExpression);
                Console.WriteLine("Результат выражения: {0}", Result);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ReadLine();
        }
    }
}
