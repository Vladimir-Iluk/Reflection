using System.Reflection;

class Program
{
    static void Main()
    {
        Type type = typeof(BlackBoxInteger);
        ConstructorInfo constr = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(int) }, null);
        var constructor = constr.Invoke(new object[] { 0 });
        var Add = typeof(BlackBoxInteger).GetMethod("Add", BindingFlags.Instance | BindingFlags.NonPublic);
        var Subtract = typeof(BlackBoxInteger).GetMethod("Subtract", BindingFlags.Instance | BindingFlags.NonPublic);
        var Multiply = typeof(BlackBoxInteger).GetMethod("Multiply", BindingFlags.Instance | BindingFlags.NonPublic);
        var Divide = typeof(BlackBoxInteger).GetMethod("Divide", BindingFlags.Instance | BindingFlags.NonPublic);
        var LeftShift = typeof(BlackBoxInteger).GetMethod("LeftShift", BindingFlags.Instance | BindingFlags.NonPublic);
        var RightShift = typeof(BlackBoxInteger).GetMethod("RightShift", BindingFlags.Instance | BindingFlags.NonPublic);
        var innerValue = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

        string input;
        do
        {
            Console.WriteLine("Add;Subtract;Multiply;Divide;LeftShift;RightShift;");
            input = Console.ReadLine();

            switch (input)
            {

                case "Add":
                    Console.Write("\nInput int - ");
                    int add = int.Parse(Console.ReadLine());
                    Add?.Invoke(constructor, parameters: new object[] { add });
                    Console.WriteLine($"Result - {innerValue.GetValue(constructor)}");
                    break;
                case "Subtract":
                    Console.Write("Input subtract - ");
                    int subtract = int.Parse(Console.ReadLine());
                    Subtract?.Invoke(constructor, parameters: new object[] { subtract });
                    Console.WriteLine($"Result - {innerValue.GetValue(constructor)}");
                    break;
                case "Multiply":
                    Console.WriteLine("Input multiply");
                    int multiply = int.Parse(Console.ReadLine());   
                    Multiply?.Invoke(constructor, new object[] { multiply });
                    Console.WriteLine($"Result - {innerValue.GetValue(constructor)}");
                    break;
                case "Divide":
                    Console.WriteLine("Input divide");
                    int divide = int.Parse(Console.ReadLine());
                    Divide?.Invoke(constructor, new object[] { divide });
                    Console.WriteLine($"Result - {innerValue.GetValue(constructor)}");
                    break;
                case "LeftShift":
                    Console.WriteLine("Input left shift");
                    int leftShift = int.Parse(Console.ReadLine());
                    LeftShift?.Invoke(constructor, new object[] { leftShift });
                    Console.WriteLine($"Result - {innerValue.GetValue(constructor)}");
                    break;
                case "RightShift":
                    Console.WriteLine("Input right shift");
                    int rightShift = int.Parse(Console.ReadLine());
                    RightShift?.Invoke(constructor, new object[] { rightShift });
                    Console.WriteLine($"Result - {innerValue.GetValue(constructor)}");
                    break;
            }
        } while (input != "end");
    }
}