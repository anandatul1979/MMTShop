using Microsoft.Extensions.DependencyInjection;
using Console.Strategies;
using Core;
using System;
using System.IO;

namespace Console
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<IProgramInput>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Strategies.IProgramInput, ShowCategories>();
            services.AddSingleton<Strategies.IProgramInput, ShowFeaturedProducts>();
            services.AddSingleton<Strategies.IProgramInput, ShowProductsInCategory>();

            services.AddSingleton<IProgramInput, ProgramInput>();   

            services.AddHttpClient(Strings.DemoClient, x =>
            {
                x.BaseAddress = new Uri(Environment.GetEnvironmentVariable(CommonVariables.ApiUrl));
            });

            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }

            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
