using System.Reflection;

class Program
{
    static void Main()
    {
        Console.WriteLine("Input signals - ");
        string input = Console.ReadLine();
        Console.WriteLine("Input n");
        int n = int.Parse(Console.ReadLine());
        string[] colors = input.Split(' ');
        TraficLight[] lights = new TraficLight[colors.Length];
        Type type = typeof(TraficLight);
        ConstructorInfo constr = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
        for (int i = 0; i < colors.Length; i++)
        {
            lights[i] = (TraficLight)constr.Invoke(new object[] { colors[i] });
        }
        var ChangeColor = typeof(TraficLight).GetMethod("ChangeColor", BindingFlags.Instance | BindingFlags.NonPublic);
        var GetColor = typeof(TraficLight).GetMethod("GetColor", BindingFlags.Instance | BindingFlags.NonPublic);
        for (int cycle = 0; cycle < n; cycle++)
        {
            foreach (var light in lights)
            {
                ChangeColor.Invoke(light, null);
            }
            foreach (var light in lights)
            {
                string currentColor = (string)GetColor.Invoke(light, null);
                Console.Write(currentColor + " ");
            }
            Console.WriteLine();
        }

    }
}