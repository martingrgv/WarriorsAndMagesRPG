using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models.Enums;
using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Services
{
    public class MenuService : IMenuService
    {
        IPrinterService _printerService { get; set; }

        public MenuService(IPrinterService printerService)
        {
            _printerService = printerService;
        }

        public void ShowMenu(Menu menu)
        {
            _printerService.Clear();

            switch (menu)
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
    }
}
