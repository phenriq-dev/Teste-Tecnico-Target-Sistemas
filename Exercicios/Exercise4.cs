using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public static class Exercise4
    {
        public static void Run()
        {
            List<(string State, double Revenue)> revenueByState = new List<(string, double)>
            {
                ("SP", 67836.43),
                ("RJ", 36678.66),
                ("MG", 29229.88),
                ("ES", 27165.48),
                ("Outros", 19849.53)
            };

            double totalRevenue = 0;
            foreach (var item in revenueByState)
            {
                totalRevenue += item.Revenue;
            }

            Console.WriteLine("Porcentagem de faturamento por estado:");
            foreach (var item in revenueByState)
            {
                double percentage = (item.Revenue / totalRevenue) * 100;
                Console.WriteLine($"{item.State}: {percentage:F2}%");
            }

            Console.ReadLine();
        }
    }
}
