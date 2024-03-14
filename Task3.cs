using System;
using System.IO;
using System.Threading.Tasks;

class WordSearch
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Какое слово ищем?:");
        string word = Console.ReadLine();

        Console.WriteLine("Укажи путь к файлу ( Пример: C:\\Users\\2007n\\Desktop\\SQLQuery2.txt ) :");
        string filePath = Console.ReadLine();

        try
        {
            int count = await SearchWordAsync(filePath, word);
            Console.WriteLine($"Слово '{word}' встречается {count} раз в файле.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"произошла проблем: {ex.Message}");
        }
    }

    static async Task<int> SearchWordAsync(string filePath, string word)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string content = await reader.ReadToEndAsync();
            int index = 0;
            int count = 0;
            while ((index = content.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }
            return count;
        }
    }
}
