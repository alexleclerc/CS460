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
            string Output = "4";
            Input = Console.ReadLine();

            if (Input.StartsWith("q") || Input.StartsWith("Q"))
            {
                return false;
            }

            try
            {
                Output = EvaluatePostFixInput(Input);
            }
            catch (Exception e)
            {
                Output = e.Message;
            }

            Console.WriteLine("\n\t >>> " + Input + " = " + Output);
            return true;
        }

        public string EvaluatePostFixInput(string input)
        {
            
            if (input == null || input.Equals(""))
            {
                throw new ArgumentException("Null or empty strings are not valid.", input);
            }
            Stack.Clear();

            //look for one or more digits (optionally with decimals)
            //followed separted by a space, followed by an operator
            string Pattern = @"(\d+(?:\.\d+)*)\s(\d+(?:\.\d+)*)\s*([\+\-\*\/])";
            Match InputMatch = Regex.Match(input, Pattern);

            double result;

            if (InputMatch.Success)
            {
                //convert the Regex matches to doubles, put them on the stack.
                Stack.Push(double.Parse(InputMatch.Groups[1].Value));
                Stack.Push(double.Parse(InputMatch.Groups[2].Value));
                Stack.Push(InputMatch.Groups[3].Value.ToString());
                result = DoOperation();
                
            }
            else
            {
                throw new ArgumentException("Improper input. (not in 'a b +' form)", input);
            }
            Stack.Push(result);
            return Stack.Pop().ToString();
        }

        public double DoOperation()
        {
            string op; //operator
            double a;  //first operand
            double b;  //second operand
            double c;  //answer

            //pop the top item into the operator
            op = Stack.Pop().ToString();
            b = Convert.ToDouble(Stack.Pop());
            a = Convert.ToDouble(Stack.Pop());

            switch (op)
            {
                case "+" :
                    c = (a + b);
                    break;
                case "-" :
                    c = (a - b);
                    break;
                case "*" :
                    c = (a * b);
                    break;
                case "/":
                    try
                    {
                        c = (a / b);
                        if (c == double.PositiveInfinity || c == double.NegativeInfinity)
                        {
                            throw new ArgumentException("Cannot divide by zero.");
                        }
                    }
                    catch (ArithmeticException)
                    {
                        throw new ArgumentException("Improper operation.");
                    }
                    break;

                default:
                    throw new ArgumentException("{0} is not a proper operator.", op);
            
            }
            return c;
        }
    }
}
