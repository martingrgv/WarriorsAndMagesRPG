using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Infrastructure;
using WarriorsAndMagesRPG.Infrastructure.Models;

namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface IController
    {
        CharacterViewModel GetCharacter(char choice);
        int AddStatsToCharacter(CharacterViewModel character, string statName, int points);
        void LogCharacter(CharacterViewModel characterViewModel);
    }
}
