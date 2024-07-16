using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models;
using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core
{
    public class Controller : IController
    {
        IPrinterService _printerService;
        IReaderService _readerService;

        public Controller(IPrinterService printerService, IReaderService readerService)
        {
            _printerService = printerService;
            _readerService = readerService;     
        }

        public int AddStatsToCharacter(Character character, string statName, int points)
        {
            _printerService.Print($"Add to {statName}: ");
            if (int.TryParse(_readerService.Read(), out int pointsToAdd))
            {
                if (pointsToAdd > points)
                {
                    throw new ArgumentException($"Cannot add {pointsToAdd} when you only have {points} to spare!");
                }

                switch (statName)
                {
                    case "Strenght":
                        character.Strength += pointsToAdd;
                        break;
                    case "Agility":
                        character.Agility += pointsToAdd;
                        break;
                    case "Intelligence":
                        character.Intelligence += pointsToAdd;
                        break;
                    default:
                        throw new ArgumentException($"There is no valid character status with name {statName}");
                }

                return points - pointsToAdd;
            }
            else
            {
                throw new ArgumentException("Invalid input! Possibly not a number.");
            }


        }

        public Character GetCharacter(char choice)
        {
            switch (choice)
            {
                case '1':
                    return new Warrior();
                case '2':
                    return new Archer();
                case '3':
                    return new Mage();
            }

            throw new ArgumentException($"Character by choice {choice} could not be created! Possibly not existing.");
        }
    }
}
