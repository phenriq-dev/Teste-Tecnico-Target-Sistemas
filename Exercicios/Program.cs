using Exercises.Enums;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selecione um exercício para executar:");
            Console.WriteLine("1 - Soma dos números de 1 a 13");
            Console.WriteLine("2 - Sequência de Fibonacci");
            Console.WriteLine("3 - Faturamento diário");
            Console.WriteLine("4 - Percentual de representação por estado");
            Console.WriteLine("5 - Inverter string");
            Console.WriteLine();

            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            if (Enum.IsDefined(typeof(Exercise), choice))
            {
                if (choice == 3)
                {

                    Console.WriteLine("Selecione a fonte de dados utilizar:");
                    Console.WriteLine("1 - .json");
                    Console.WriteLine("2 - .xml");
                    Console.WriteLine();

                    int choiceDataSource = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (Enum.IsDefined(typeof(DataSource), choiceDataSource))
                    {
                        DataSource selectedDataSource = (DataSource)choiceDataSource;

                        Exercise3.Run(selectedDataSource);
                    }
                    else
                    {
                        Console.WriteLine("Fonte de dados inválida!");
                    }
                }
                else
                {
                    Exercise selectedExercise = (Exercise)choice;
                    Action chosenExercise = GetExerciseToRun(selectedExercise);

                    chosenExercise?.Invoke();
                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        
        }

        public static Action GetExerciseToRun(Exercise exercise)
        {
            return exercise switch
            {
                Exercise.Sum => Exercise1.Run,
                Exercise.Fibonacci => Exercise2.Run,
                //Exercise.RevenueCalculation => Exercise3.Run,
                Exercise.StatePercentage => Exercise4.Run,
                Exercise.ReverseString => Exercise5.Run,
                _ => null
            };
        }

    }
}
