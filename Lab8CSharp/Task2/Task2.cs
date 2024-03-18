using System;
using System.IO;
using System.Text.RegularExpressions;

class Program2
{
    public static void Task2()
    {
        // Зчитуємо вміст вхідного файлу
        string inputFile = "/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task2/input.txt";
        string text = File.ReadAllText(inputFile);

        // Задаємо регулярні вирази для пошуку слів
        string[] patternsToRemove = { @"\b\w*re\b", @"\b\w*nd\b", @"\b\w*less\b" };
        string patternToReplace = @"\bto\w*\b";

        // Виконуємо видалення та заміну слів
        foreach (string pattern in patternsToRemove)
        {
            text = Regex.Replace(text, pattern, string.Empty);
        }
        text = Regex.Replace(text, patternToReplace, "at$0");

        // Записуємо змінений текст у новий файл
        string outputFile = "/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task2/output.txt";
        File.WriteAllText(outputFile, text);

        Console.WriteLine("Операція завершена. Результат записано у файл output.txt");
    }
}
