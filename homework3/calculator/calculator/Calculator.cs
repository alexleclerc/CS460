using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Calculator
    {
        //private IStackADT Stack = new LinkedStack();

        static void Main(string[] args)
        {
            Calculator app = new Calculator();
            bool PlayAgain = true;
            Console.WriteLine("Postfix Calculator. Recognizes these operators: + - * /");
            while (PlayAgain)
            {
                PlayAgain = true;
            }
            Console.WriteLine("Bye.");
        }
    }
}
