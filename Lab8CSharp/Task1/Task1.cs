using System;
using System.IO;
using System.Text.RegularExpressions;

class Program1
{
    static string outputFile = "/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task1/output.txt"; 

    public static void Task1()
    {
        ClearOutputFile();

        // Зчитуємо вміст вхідного файлу
        string inputFile = "/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task1/input.txt";
        string text = File.ReadAllText(inputFile);

        // Задаємо регулярний вираз для пошуку IP-адрес
        string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";

        while (true)
        {
            // Виводимо меню опцій
            Console.WriteLine("Оберіть опцію:");
            Console.WriteLine("1. Пошук");
            Console.WriteLine("2. Підрахунок кількості входжень");
            Console.WriteLine("3. Пошук із заміною на нове значення");
            Console.WriteLine("4. Заміна конкретної IP-адреси");
            Console.WriteLine("5. Вихід");

            // Зчитуємо вибір користувача
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Search(text, pattern);
                    break;
                case "2":
                    CountOccurrences(text, pattern);
                    break;
                case "3":
                    ReplaceIP(text, pattern);
                    break;
                case "4":
                    ReplaceSpecificIP(text, pattern);
                    break;
                case "5":
                    Console.WriteLine("Програма завершена.");
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Будь ласка, виберіть опцію зі списку.");
                    break;
            }
        }
    }

    static void ClearOutputFile()
    {
        File.WriteAllText(outputFile, string.Empty);
    }

    static void Search(string text, string pattern)
    {
        // Знаходимо всі входження IP-адрес у тексті
        MatchCollection matches = Regex.Matches(text, pattern);

        // Виводимо знайдені IP-адреси
        Console.WriteLine("Знайдені IP-адреси:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
            // Write found IP addresses to the output file
            File.AppendAllText(outputFile, match.Value + Environment.NewLine);
        }
    }

    static void CountOccurrences(string text, string pattern)
    {
        // Знаходимо всі входження IP-адрес у тексті
        MatchCollection matches = Regex.Matches(text, pattern);

        // Виводимо кількість знайдених IP-адрес
        Console.WriteLine($"Загальна кількість IP-адрес: {matches.Count}");
        // Write the count of found IP addresses to the output file
        File.AppendAllText(outputFile, $"Загальна кількість IP-адрес: {matches.Count}" + Environment.NewLine);
    }

    static void ReplaceIP(string text, string pattern)
    {
        // Зчитуємо нове значення для заміни
        Console.Write("Введіть нове значення для заміни IP-адрес: ");
        string newValue = Console.ReadLine();

        // Замінюємо всі знайдені IP-адреси на нове значення
        string newText = Regex.Replace(text, pattern, newValue);

        // Write modified text to the output file
        File.AppendAllText(outputFile, newText);
        Console.WriteLine($"Текст зі зміненими IP-адресами записаний у файл {outputFile}");
    }


    static void ReplaceSpecificIP(string text, string pattern)
    {
        // Зчитуємо IP-адресу, яку користувач хоче замінити
        string ipToReplace;
        do
        {
            Console.Write("Введіть IP-адресу для заміни: ");
            ipToReplace = Console.ReadLine();
            if (!Regex.IsMatch(ipToReplace, pattern))
            {
                Console.WriteLine("Введена IP-адреса не відповідає формату. Будь ласка, введіть коректну IP-адресу.");
            }
        } while (!Regex.IsMatch(ipToReplace, pattern));

        // Зчитуємо нове значення IP-адреси
        Console.Write("Введіть нову IP-адресу: ");
        string newIP = Console.ReadLine();

        // Замінюємо знайдену IP-адресу на нову, якщо така існує
        string newText = Regex.Replace(text, ipToReplace, newIP);

        // Write modified text to the output file
        File.AppendAllText(outputFile, newText);
        Console.WriteLine($"Текст зі зміненою IP-адресою записаний у файл {outputFile}");
    }
}
