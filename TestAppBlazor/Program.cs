using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReflectionTest.ThingLibrary;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestAppBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

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

            await builder.Build().RunAsync();
        }
    }
}
