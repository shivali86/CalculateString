using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateString
{
    class Program
    {
        static void Main(string[] args)
        {
           

            // Get user input
            Console.WriteLine("Enter the operation you want to perform:");
            string inputString = Console.ReadLine();

            decimal result = 0;

            ArithmaticOperation arithmaticOperation = new ArithmaticOperation();
            result=arithmaticOperation.ProcessOperation(inputString);


            Console.WriteLine("Result:{0}", result);
            Console.Write("\nPress any key to exit...");

            Console.ReadKey();
        }
    }
}
