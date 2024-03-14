using System;
using System.Threading;

class HorseRace
{
    static readonly int NUM_HORSES = 5;
    static Random rand = new Random();
    static object locker = new object();

    static void Main(string[] args)
    {
        Thread[] threads = new Thread[NUM_HORSES];
        for (int i = 0; i < NUM_HORSES; i++)
        {
            threads[i] = new Thread(RunHorse);
            threads[i].Start(i + 1);
        }

        Console.WriteLine("Нажми чё-то для старта");
        Console.ReadKey();
        Console.WriteLine("Погнали!");

        for (int i = 0; i < NUM_HORSES; i++)
        {
            threads[i].Join();
        }

        Console.WriteLine("Гонка овер!");
    }

    static void RunHorse(object horseNumber)
    {
        int distance = 0;
        while (distance < 100)
        {
            lock (locker)
            {
                distance += rand.Next(1, 11);
                Console.WriteLine($"Лошадь {horseNumber} пробежала {distance} метресов!");
            }
            Thread.Sleep(100);
        }
        Console.WriteLine($"Лошадь {horseNumber} завершила гонку!");
    }
}
