using System;
using System.IO;

class Program4
{
    public static void Task4()
    {
        // Створюємо послідовність дійсних чисел
        double[] numbers = { 12.5, 3.8, 7.2, 10.6, 15.4, 8.9 };
        Console.WriteLine("Числа: " + string.Join(", ", numbers));

        // Записуємо числа у файл у двійковому форматі
        WriteBinaryFile(numbers, "/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task4/data.bin");

        // Зчитуємо числа з файлу
        double[] readNumbers = ReadBinaryFile("/Users/andriifedoryshyn/Desktop/2024/C#/csharplab8-AndriyFedoryshyn/Lab8CSharp/Task4/data.bin");

        // Знаходимо максимальне значення серед чисел, що розташовуються на непарних позиціях
        double maxOddPosition = FindMaxOddPosition(readNumbers);

        Console.WriteLine($"Максимальне значення на непарних позиціях: {maxOddPosition}");
    }

    static void WriteBinaryFile(double[] numbers, string fileName)
    {
        // Використовуємо BinaryWriter для запису чисел у двійковий файл
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
        {
            foreach (double number in numbers)
            {
                writer.Write(number);
            }
        }
    }

    static double[] ReadBinaryFile(string fileName)
    {
        // Використовуємо BinaryReader для зчитування чисел з двійкового файлу
        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
        {
            int length = (int)(reader.BaseStream.Length / sizeof(double));
            double[] numbers = new double[length];

            for (int i = 0; i < length; i++)
            {
                numbers[i] = reader.ReadDouble();
            }

            return numbers;
        }
    }

    static double FindMaxOddPosition(double[] numbers)
    {
        double max = double.MinValue;

        for (int i = 0; i < numbers.Length; i += 2)
        {
            Console.WriteLine(numbers[i]);
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }
}
