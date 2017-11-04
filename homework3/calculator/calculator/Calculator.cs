using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CalculatorApp
{
    class Calculator
    {
        private IStackADT Stack = new LinkedStack();

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

            EvaluatePostFixInput(Input);

            Console.WriteLine(Input);
            Console.WriteLine(Output);

            return true;
        }

        public string EvaluatePostFixInput(string input)
        {
            
            if (input == null || input.Equals(""))
            {
                throw new ArgumentException("Null or empty strings are not valid.", input);
            }
            Stack.Clear();

            string Pattern = @"(\d+)\s(\d+)\s([\+\-\*\/])";
            Match InputMatch = Regex.Match(input, Pattern);
            if (InputMatch.Success)
            {
                Console.WriteLine("'{0}' in '{1}' was successful.", InputMatch.Value, input);
            }
            else
            {
                Console.WriteLine("'{0}' in '{1}' was not successful.", InputMatch.Value, input);
            }
            return "nope";
        }
    }
}
