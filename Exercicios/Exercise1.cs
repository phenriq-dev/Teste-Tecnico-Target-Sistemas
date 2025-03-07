using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public static class Exercise1
    {
        public static void Run()
        {
            int index = 13, sum = 0, k = 0;
            while (k < index)
            {
                k = k + 1;
                sum = sum + k;
            }
            Console.WriteLine();
            Console.WriteLine("Resultado: " + sum);
        }
    }
}
