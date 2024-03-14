using System;

class Fibonacci
{
    static void Main(string[] args)
    {
        Console.WriteLine("Дай лимит:");
        int limit = int.Parse(Console.ReadLine());

        Console.WriteLine("Круг фибоначи(я хз как назвать):");
        for (int i = 0; i <= limit; i++)
        {
            Console.WriteLine($"Фибоначи({i}) = {CalculateFibonacci(i)}");
        }
    }

    static int CalculateFibonacci(int n)
    {
        if (n <= 1)
            return n;
        else
            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
    }
}
