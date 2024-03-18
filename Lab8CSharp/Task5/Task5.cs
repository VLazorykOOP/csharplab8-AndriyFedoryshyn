using System;
using System.IO;

class Program5
{
    public static void Task5()
    {
        string rootPath = "/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task5";

        // Крок 1: Створення папок Fedoryshyn1 і Fedoryshyn2
        CreateDirectories(rootPath);

        // Крок 2: Запис тексту у файли t1.txt і t2.txt
        WriteTextToFile(rootPath);

        // Крок 3: Переписування тексту з файлів t1.txt і t2.txt у файл t3.txt
        CopyTextFromFiles(rootPath);

        // Крок 4: Виведення розгорнутої інформації про створені файли
        DisplayFileInfo(rootPath);

        // Крок 5: Перенесення файлу t2.txt у папку Fedoryshyn2
        MoveFileToDirectory(rootPath);

        // Крок 6: Копіювання файлу t1.txt в папку Fedoryshyn2
        CopyFileToDirectory(rootPath);

        // Крок 7: Перейменування папки K2 у ALL та вилучення папки Fedoryshyn1
        RenameAndDeleteDirectories(rootPath);

        // Крок 8: Виведення повної інформації про файли папки ALL
        DisplayAllFileInfo(rootPath);
    }

    static void CreateDirectories(string rootPath)
    {
        Console.WriteLine("Крок 1: Створення папок Fedoryshyn1 і Fedoryshyn2");
        string directory1 = Path.Combine(rootPath, "Fedoryshyn1");
        string directory2 = Path.Combine(rootPath, "Fedoryshyn2");

        Directory.CreateDirectory(directory1);
        Directory.CreateDirectory(directory2);
        Console.WriteLine("Папки Fedoryshyn1 і Fedoryshyn2 успішно створені.");

        WaitForUserInput();
    }

    static void WriteTextToFile(string rootPath)
    {
        Console.WriteLine("Крок 2: Запис тексту у файли t1.txt і t2.txt");

        string text1 = "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>";
        string text2 = "<Комар Сергій Федорович, 2000 > року народження, місце проживання <м. Київ>";

        File.WriteAllText(Path.Combine(rootPath, "Fedoryshyn1", "t1.txt"), text1);
        File.WriteAllText(Path.Combine(rootPath, "Fedoryshyn1", "t2.txt"), text2);

        Console.WriteLine("Тексти успішно записані у файли t1.txt і t2.txt.");

        WaitForUserInput();
    }

    static void CopyTextFromFiles(string rootPath)
    {
        Console.WriteLine("Крок 3: Переписування тексту з файлів t1.txt і t2.txt у файл t3.txt");

        string text1 = File.ReadAllText(Path.Combine(rootPath, "Fedoryshyn1", "t1.txt"));
        string text2 = File.ReadAllText(Path.Combine(rootPath, "Fedoryshyn1", "t2.txt"));

        File.WriteAllText(Path.Combine(rootPath, "Fedoryshyn2", "t3.txt"), text1 + Environment.NewLine + text2);

        Console.WriteLine("Текст успішно переписаний у файл t3.txt.");

        WaitForUserInput();
    }

    static void DisplayFileInfo(string rootPath)
    {
        Console.WriteLine("Крок 4: Виведення розгорнутої інформації про створені файли");

        string[] files = Directory.GetFiles(Path.Combine(rootPath, "Fedoryshyn1"));
        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            Console.WriteLine($"Ім'я файлу: {fileInfo.Name}");
            Console.WriteLine($"Розмір файлу: {fileInfo.Length} байт");
            Console.WriteLine($"Дата створення: {fileInfo.CreationTime}");
            Console.WriteLine();
        }

        WaitForUserInput();
    }

    static void MoveFileToDirectory(string rootPath)
    {
        Console.WriteLine("Крок 5: Перенесення файлу t2.txt у папку Fedoryshyn2");

        string sourceFile = Path.Combine(rootPath, "Fedoryshyn1", "t2.txt");
        string destinationDirectory = Path.Combine(rootPath, "Fedoryshyn2");

        File.Move(sourceFile, Path.Combine(destinationDirectory, "t2.txt"));

        Console.WriteLine("Файл t2.txt успішно перенесений у папку Fedoryshyn2.");

        WaitForUserInput();
    }

    static void CopyFileToDirectory(string rootPath)
    {
        Console.WriteLine("Крок 6: Копіювання файлу t1.txt в папку Fedoryshyn2");

        string sourceFile = Path.Combine(rootPath, "Fedoryshyn1", "t1.txt");
        string destinationDirectory = Path.Combine(rootPath, "Fedoryshyn2");

        File.Copy(sourceFile, Path.Combine(destinationDirectory, "t1.txt"));

        Console.WriteLine("Файл t1.txt успішно скопійований у папку Fedoryshyn2.");

        WaitForUserInput();
    }

    static void RenameAndDeleteDirectories(string rootPath)
{
    Console.WriteLine("Крок 7: Перейменування папки K2 у ALL та вилучення папки Fedoryshyn1");

    string directory1 = Path.Combine(rootPath, "Fedoryshyn1");
    string directory2 = Path.Combine(rootPath, "Fedoryshyn2");

    Directory.Move(directory2, Path.Combine(rootPath, "ALL"));
    Directory.Delete(directory1, true);

    Console.WriteLine("Папка Fedoryshyn1 вилучена, а папка Fedoryshyn2 перейменована у ALL.");

    WaitForUserInput();
}


    static void DisplayAllFileInfo(string rootPath)
    {
        Console.WriteLine("Крок 8: Виведення повної інформації про файли папки ALL");

        string[] files = Directory.GetFiles(Path.Combine(rootPath, "ALL"), "*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            Console.WriteLine($"Ім'я файлу: {fileInfo.Name}");
            Console.WriteLine($"Розмір файлу: {fileInfo.Length} байт");
            Console.WriteLine($"Дата створення: {fileInfo.CreationTime}");
            Console.WriteLine();
        }

        WaitForUserInput();
    }

    static void WaitForUserInput()
    {
        Console.WriteLine("Натисніть 'y' або 'Y', щоб продовжити...");
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.KeyChar == 'y' || keyInfo.KeyChar == 'Y')
                break;
        }
    }
}
