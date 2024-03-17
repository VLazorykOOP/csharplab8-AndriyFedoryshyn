using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //menu what task to execute using while loop
        while (true)
        {
            Console.WriteLine("Choose task to execute: 1, 2, 3, 4, 5, 6-exit");
            string task = Console.ReadLine();
            switch (task)
            {
                case "1":
                    Program1.Task1();
                    break;  
                case "2":
                    Program2.Task2();
                    break;
                case "3":
                    Program3.Task3();
                    break;
                case "4":
                    Program4.Task4();
                    break;
                case "5":
                    Program5.Task5();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Task not found");
                    break;
            }
        }
    }
}
