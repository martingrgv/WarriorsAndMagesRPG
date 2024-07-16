using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Infrastructure;

namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface IController
    {
        CharacterViewModel GetCharacter(char choice);
        int AddStatsToCharacter(CharacterViewModel character, string statName, int points);
        void LogCharacter(CharacterViewModel characterViewModel);
    }
}
