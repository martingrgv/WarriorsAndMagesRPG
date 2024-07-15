using Microsoft.Extensions.DependencyInjection;
using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models.Enums;
using WarriorsAndMagesRPG.Core.Services;

namespace WarriorsAndMagesRPG.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider _serviceProvider;

        public Engine()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPrinterService, ConsolePrinterService>();
            services.AddSingleton<IReaderService, ConsoleReaderService>();
            services.AddSingleton<IMenuService, MenuService>();
        }

        public void Run()
        {
            IPrinterService printer = _serviceProvider.GetService<IPrinterService>()!;
            IReaderService reader = _serviceProvider.GetService<IReaderService>()!;
            IMenuService menuService = _serviceProvider.GetService<IMenuService>()!;

            while (true)
            {
                printer.PrintLine(menuService.GetMenu(Menu.MainMenu));
                reader.ReadKey();

                break;
            }
        }

        public void Stop()
        {
            return;
        }
    }
}
