using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public static class Exercise2
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.Write("Enter a number to check if it belongs to the Fibonacci sequence: ");
            int number = int.Parse(Console.ReadLine());

            int a = 0, b = 1, fib = 0;

            while (fib < number) {

                fib = a + b;
                a = b;
                b = fib;

            }

            Console.WriteLine();

            if (fib == number)
                Console.WriteLine($"The number {number} belongs to the Fibonacci sequence.");
            else
                Console.WriteLine($"The number {number} does not belong to the Fibonacci sequence.");

        }
    }
}
