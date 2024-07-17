using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Infrastructure;
using WarriorsAndMagesRPG.Infrastructure.Models;

namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface IController
    {
        Models.Character GetCharacter(char choice);
        int AddStatsToCharacter(Models.Character character, string statName, int points);
        void LogCharacter(Models.Character characterViewModel);
    }
}
