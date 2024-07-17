using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Core.Models.Enums;
using WarriorsAndMagesRPG.Infrastructure.Models;
using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Services
{
    public class MenuService : IMenuService
    {
        private IGameplayService _gameplayService;
        private IPrinterService _printerService;
        private Menu _menu;

        public MenuService(IPrinterService printerService, IGameplayService gameplayService)
        {
            _printerService = printerService;
            _gameplayService = gameplayService;
        }

        public void ShowMenu()
        {
            _printerService.Clear();

            switch (_menu)
            {
                case Menu.MainMenu:
                    _printerService.PrintLine(MAIN_MENU_TEXT);
                    break;
                case Menu.CharacterSelect:
                    _printerService.PrintLine(CHARACTER_SELECT_MENU_TEXT);
                    break;
                case Menu.Exit:
                    _printerService.PrintLine(EXIT_TEXT);
                    break;
            }
        }
        public void ShowMenu(int[,] gameField, CharacterViewModel character)
        {
            _gameplayService.StartGame(gameField, character);
        }

        public void SetMenu(Menu menu)
        {
            _menu = menu;
        }
    }
}
