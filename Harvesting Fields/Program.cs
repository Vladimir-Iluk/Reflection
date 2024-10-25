using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        Type type = typeof(HarvestingFields);
        Console.WriteLine("Fields :");
        string input;
        do
        {
            input = Console.ReadLine(); 
            switch (input)
            {
                case "private":
                    foreach(FieldInfo field in type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance ))
                    {
                        string modificator = "";
                        if (field.IsPrivate)
                        {
                            modificator += "private";
                            Console.WriteLine($"{modificator} {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                case "protected":
                    foreach(FieldInfo field in type.GetFields(BindingFlags.DeclaredOnly| BindingFlags.NonPublic | BindingFlags.Instance))
                    {
                        string modificator = "";
                        if (field.IsFamily)
                        {
                            modificator += "protected";
                            Console.WriteLine($"{modificator} {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                case "public":
                    foreach (FieldInfo field in type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
                    {
                        string modificator = "";
                        if (field.IsPublic)
                        {
                            modificator += "public";
                            Console.WriteLine($"{modificator} {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                case "all":
                    foreach (FieldInfo field in type.GetFields(
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)) { 
                        string modificator = "";
                        if (field.IsPublic)
                            modificator += "public ";
                        else if (field.IsPrivate)
                            modificator += "private ";
                        else if (field.IsAssembly)
                            modificator += "internal ";
                        else if (field.IsFamily)
                            modificator += "protected ";
                        else if (field.IsFamilyAndAssembly)
                            modificator += "private protected ";
                        else if (field.IsFamilyOrAssembly)
                            modificator += "protected internal ";
                        if (field.IsStatic) modificator += "static ";
                        Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
                    }
                    break;
            }
        } while (input != "end");

    }
}