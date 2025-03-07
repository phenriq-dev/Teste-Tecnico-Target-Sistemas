using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public static class Exercise5
    {
        public static void Run()
        {
            Console.Write("Digite uma palavra: ");
            string entrada = Console.ReadLine();

            string resultado = InverterString(entrada);
            Console.WriteLine($"String invertida: {resultado}");
        }
        public static string InverterString(string str)
        {
            if (str.Length == 0 || str.Length == 1)
                return str;

            var reverseString = str.Substring(str.Length - 1);

            return reverseString + InverterString(str.Substring(0, str.Length - 1));
        }
    }
}
