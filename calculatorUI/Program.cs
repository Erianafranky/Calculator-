using System;
using System.Collections.Generic;
using CalculatorLibrary;

namespace calculatorUI
{
    class Program
    {
        private static List<string> history = new List<String>();
        static void Main(string[] args)
        {
            bool endApp = false;
            //Display title
            Console.WriteLine("Calculator Application\r");
            Console.WriteLine("----------------------------\n");
            
            Calc calculator = new Calc();
            while (!endApp)
            {
                string firstInput = "";
                string secondInput = "";
                double result = 0;

                //Ask the user to enter a value
                Console.Write("Type a number and press Enter: ");
                firstInput = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(firstInput, out cleanNum1))
                {
                    Console.Write("Invalid input. Please enter integer number: ");
                    firstInput = Console.ReadLine();
                }

                //Ask the user to enter the second number
                 Console.Write("Type another number and press Enter: ");
                secondInput = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(secondInput, out cleanNum2))
                {
                    Console.Write("Invalid input. Please enter integer number: ");
                    secondInput = Console.ReadLine();
                }

                //Ask the user to choose an operator
                Console.WriteLine("Choose an operator: ");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tq - Square");
                Console.WriteLine("Your option?");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This will cause a mathematical error.\n");

                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occured trying to do the math. \n - Details: " + e.Message);
                    
                }
                Console.WriteLine("--------------------------\n");

                Console.Write("Press 'n' and Enter to close the app or press any other key and enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            //calculator.Finish();
            return;
        }
        private static void AddHistory(string message)
        {
            history.Insert(0, message);
            //if(history.Count > 5)
               // history.Remove(5);
        }
    }
}
