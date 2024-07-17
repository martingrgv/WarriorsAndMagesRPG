using WarriorsAndMagesRPG.Core.Models;

namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface IGameplayService
    {
        void StartGame(int[,] gameField, CharacterViewModel character);
    }
}
