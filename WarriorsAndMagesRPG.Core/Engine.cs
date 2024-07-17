using Microsoft.Extensions.DependencyInjection;
using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Core.Models.Enums;
using WarriorsAndMagesRPG.Core.Services;
using WarriorsAndMagesRPG.Infrastructure;
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
            services.AddDbContext<WarriorsAndMagesContext>();

            services.AddSingleton<IPrinterService, ConsolePrinterService>();
            services.AddSingleton<IReaderService, ConsoleReaderService>();
            services.AddSingleton<IMenuService, MenuService>();
            services.AddSingleton<IController, Controller>();
            services.AddSingleton<IGameplayService, GameplayService>();
        }

        public void Run()
        {
            IPrinterService printerService = _serviceProvider.GetService<IPrinterService>()!;
            IReaderService reader = _serviceProvider.GetService<IReaderService>()!;
            IMenuService menuService = _serviceProvider.GetService<IMenuService>()!;
            IController controller = _serviceProvider.GetService<IController>()!;

            int[,] playField = new int[GAME_FIELD_SIZE, GAME_FIELD_SIZE];
            char[] charactersRange = {'1', '2', '3'};

            while (true)
            {
                // Main Menu
                menuService.SetMenu(Menu.MainMenu);
                menuService.ShowMenu();
                reader.ReadKey();

                // Character Select Menu
                char characterChoice = default;
                while (!charactersRange.Any(c => c == characterChoice))
                {
                    menuService.SetMenu(Menu.CharacterSelect);
                    menuService.ShowMenu();
                    characterChoice = reader.ReadKey();
                }

                printerService.Clear();

                CharacterViewModel player = controller.GetCharacter(characterChoice);

                // Character Add Status
                printerService.PrintLine(STATS_ADD_TEXT);
                char statsAddChoice = reader.ReadKey();

                printerService.PrintLine();

                if (char.ToLower(statsAddChoice) == 'y')
                {
                    int points = BUFF_LIMIT_POINTS;
                    while (points > 0)
                    {
                        printerService.PrintLine($"Remaining Points: {points}");

                        try
                        {
                            points = controller.AddStatsToCharacter(player, "Strenght", points);
                            printerService.PrintLine($"Remaining Points: {points}");

                            if (points <= 0)
                                break;

                            points = controller.AddStatsToCharacter(player, "Agility", points);
                            printerService.PrintLine($"Remaining Points: {points}");

                            if (points <= 0)
                                break;

                            points = controller.AddStatsToCharacter(player, "Intelligence", points);
                            printerService.PrintLine($"Remaining Points: {points}");

                            if (points <= 0)
                                break;
                        }
                        catch (ArgumentException ae)
                        {
                            printerService.PrintLine(ae.Message);
                        }
                    }
                }

                // Setup player
                player.Setup();

                // Log character to db
                //controller.LogCharacter(player);

                // Start game
                menuService.SetMenu(Menu.InGame);
                menuService.ShowMenu(playField, player);

                // Exit Menu
                menuService.SetMenu(Menu.Exit);
                menuService.ShowMenu();
                reader.ReadKey();

                Stop();
            }
        }

        public void Stop()
        {
            Environment.Exit(0);
        }
    }
}
