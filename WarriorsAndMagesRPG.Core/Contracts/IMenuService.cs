using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Core.Models.Enums;

namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface IMenuService
    {
        void SetMenu(Menu menu);
        void ShowMenu();
        void ShowMenu(int[,] gameField, Character character);
    }
}
