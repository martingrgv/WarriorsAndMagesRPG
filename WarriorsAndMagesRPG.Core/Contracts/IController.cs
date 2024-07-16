using WarriorsAndMagesRPG.Core.Models;

namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface IController
    {
        Character GetCharacter(char choice);
        int AddStatsToCharacter(Character character, string statName, int points);
    }
}
