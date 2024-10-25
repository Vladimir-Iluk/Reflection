using System;
using System.Reflection;
using task_5;

class Task
{
    static void Main()
    {
        Type weaponType = typeof(Weapon);
        var classInfo = (ClassInfoAttribute)Attribute.GetCustomAttribute(weaponType, typeof(ClassInfoAttribute));

        while (true)
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();

            if (command == "END") break;

            switch (command)
            {
                case "Author":
                    Console.WriteLine($"Author: {classInfo.Author}");
                    break;

                case "Revision":
                    Console.WriteLine($"Revision: {classInfo.Revision}");
                    break;

                case "Description":
                    Console.WriteLine($"Class description: {classInfo.Description}");
                    break;

                case "Reviewers":
                    Console.Write("Reviewers: ");
                    foreach (string reviewer in classInfo.Reviewers)
                    {
                        Console.Write(reviewer + " ");
                    }
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }

            Line();
        }
    }

    public static void Line()
    {
        Console.WriteLine("=======================================");
    }
}
