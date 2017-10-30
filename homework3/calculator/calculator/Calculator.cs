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
            Calculator App = new Calculator();
            bool PlayAgain = true;
            Console.WriteLine("Postfix Calculator. Recognizes these operators: + - * /");
            while (PlayAgain)
            {
                PlayAgain = App.DoCalculation();
            }
            Console.WriteLine("Bye.");
        }

        private bool DoCalculation()
        {
            Console.WriteLine("Enter 'q' to quit.");
            string Input = "2 2 +";
            Console.Write("> ");

            Input = Console.ReadLine();

            if (Input.StartsWith("q") || Input.StartsWith("Q"))
            {
                return false;
            }

            string Output = "4";

            Console.WriteLine(Input);
            Console.WriteLine(Output);

            return true;
        }
    }
}
