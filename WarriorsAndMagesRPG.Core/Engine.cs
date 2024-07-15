using Microsoft.Extensions.DependencyInjection;
using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models.Enums;
using WarriorsAndMagesRPG.Core.Services;
using static WarriorsAndMagesRPG.Core.Constants;

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
            services.AddSingleton<IController, Controller>();
        }

        public void Run()
        {
            IPrinterService printer = _serviceProvider.GetService<IPrinterService>()!;
            IReaderService reader = _serviceProvider.GetService<IReaderService>()!;
            IMenuService menuService = _serviceProvider.GetService<IMenuService>()!;

            int[] charactersRange = {1, 3};

            while (true)
            {
                printer.PrintLine(menuService.GetMenu(Menu.MainMenu));
                reader.ReadKey();

                printer.Clear();

                char characterType;

                printer.PrintLine(menuService.GetMenu(Menu.CharacterSelect));
                characterType = reader.ReadKey();

                printer.Clear();

                printer.PrintLine(DEFAULT_STATS_ADD_TEXT);
                char statsAddChoice = reader.ReadKey();

                printer.PrintLine();

                if (char.ToLower(statsAddChoice) == 'y')
                {
                    int points = DEFAULT_BUFF_LIMIT_POINTS;
                    printer.PrintLine($"Remaining Points: {points}");
                    reader.ReadKey();
                }

                printer.Clear();

                printer.PrintLine(menuService.GetMenu(Menu.InGame));

                break;
            }
        }

        public void Stop()
        {
            return;
        }
    }
}
