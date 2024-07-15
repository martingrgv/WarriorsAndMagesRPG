using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models.Enums;
using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Services
{
    public class MenuService : IMenuService
    {
        public string GetMenu(Menu menu)
        {
            switch (menu)
            {
                case Menu.MainMenu:
                    return DEFAULT_MAIN_MENU_TEXT;
                case Menu.CharacterSelect:
                    return DEFAULT_CHARACTER_SELECT_MENU_TEXT;
                case Menu.InGame:
                    return null; 
                //case Menu.MainMenu:
                //    return;
                default:
                    throw new ArgumentException($"{menu} is not a valid menu!");
            }
        }
    }
}
