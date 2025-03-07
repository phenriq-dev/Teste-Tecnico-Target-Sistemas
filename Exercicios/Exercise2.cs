using System;

namespace Exercises
{
    public static class Exercise2
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.Write("Digite um número para verificar se ele pertence à sequência de Fibonacci: ");
            int number = int.Parse(Console.ReadLine());

            bool isFibonacci = IsFibonacci(number, 0, 1);

            Console.WriteLine();

            if (isFibonacci)
                Console.WriteLine($"O número {number} pertence à sequência de Fibonacci.");
            else
                Console.WriteLine($"O número {number} não pertence à sequência de Fibonacci.");
        }

        public static bool IsFibonacci(int number, int a, int b)
        {
            if (a == number)
                return true;
            if (a > number)
                return false;

            return IsFibonacci(number, b, a + b);
        }
    }
}
