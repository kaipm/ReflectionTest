using System;
using System.Reflection;
using ReflectionTest.ThingLibrary;

namespace ReflectionTest.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print reflected properties of type
            var t = typeof(Thing);

            var props = t.GetProperties(BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance);

            foreach (var prop in props)
            {
                Console.WriteLine($"Property: {prop.Name}");
            }

            Console.WriteLine("Done.");
            // --
        }
    }
}
