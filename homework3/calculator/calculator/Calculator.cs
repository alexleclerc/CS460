using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CalculatorApp
{
    /// <summary>
    /// This class holds the Main function as well as 
    /// the functions nessecary to perform arithmetic
    /// operations on user input. It has a stack that
    /// is accessible to all inner functions.
    /// </summary>
    class Calculator
    {
        private IStackADT Stack = new LinkedStack();
        
        /// <summary>
        /// Creates an instance of the calculator app
        /// and handles running the the app until the 
        /// user quits.
        /// </summary>
        static void Main(string[] args)
        {
            Calculator App = new Calculator();
            bool PlayAgain = true;
            Console.WriteLine("Postfix Calculator. Recognizes these operators: + - * /");

            //keep the app open until the user input sets PlayAgain to false
            while (PlayAgain)
            {
                PlayAgain = App.DoCalculation();
            }
            Console.WriteLine("Bye.");
        }

        /// <summary>
        /// Handles the I/O and directs the user input to the 
        /// functions that do calculation.
        /// </summary>
        /// <returns>
        /// Returns false when the user wishes 
        /// to quit (by typing 'Q' or 'q') and true otherwise
        /// </returns>
        private bool DoCalculation()
        {
            //variables with default values just in case
            string Input = "2 2 +";
            string Output = "4";

            //user prompt
            Console.WriteLine("Enter 'q' to quit.");
            Console.Write("> ");
            
            Input = Console.ReadLine();

            //if the user wants to exit we return false to quit the program
            if (Input.StartsWith("q") || Input.StartsWith("Q"))
            {
                return false;
            }

            //try to get the output, or retrieve any error messages.
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

        /// <summary>
        /// Evaluates user input, checking for errors,
        /// and returns the proper arithmetic result
        /// by calling DoOperation.
        /// 
        /// Uses the Stack to handle input and allow 
        /// other functions access.
        /// </summary>
        /// <param name="input">
        /// User input scanned from console
        /// </param>
        /// <returns>
        /// Pops the result of the calculation off
        /// the stack as a string.
        /// </returns>
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
                //use DoOperation to find the result
                result = DoOperation();
                
            }
            //or throw an error if the input doesn't match our criteria
            else
            {
                throw new ArgumentException("Improper input. (not in 'a b +' form)", input);
            }
            //push the result onto the top of the stack so it is the next thing to be popped off.
            Stack.Push(result);
            return Stack.Pop().ToString();
        }

        /// <summary>
        /// Takes three items off the stack, checks the
        /// operator type and does the appropriate calculation.
        /// Division is a special case that checks for errors
        /// that may come about from exceptional input.
        /// </summary>
        /// <returns>
        /// The result of the operation if successful.
        /// </returns>
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
