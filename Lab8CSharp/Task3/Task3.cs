using System;
using System.IO;
using System.Linq;

class Program3
{
    public static void Task3()
    {
        // Зчитуємо вміст перших двох файлів
        string file1Content = File.ReadAllText("/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task3/file1.txt");
        string file2Content = File.ReadAllText("/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task3/file2.txt");

        // Розділяємо слова першого тексту за допомогою пробілів та розділових знаків
        string[] words1 = file1Content.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        // Розділяємо слова другого тексту
        string[] words2 = file2Content.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        // Знаходимо слова з першого тексту, які не входять до другого тексту
        var wordsNotInSecond = words1.Where(word => !words2.Contains(word));

        // Формуємо рядок зі словами, розділені пробілами
        string resultText = string.Join(" ", wordsNotInSecond);

        // Записуємо результат у третій файл
        File.WriteAllText("/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task3/result.txt", resultText);

        Console.WriteLine("Операція завершена. Результат записано у файл result.txt");
    }
}
