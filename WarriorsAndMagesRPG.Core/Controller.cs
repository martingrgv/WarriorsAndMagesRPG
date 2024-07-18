using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Core.Utilities;
using WarriorsAndMagesRPG.Infrastructure;

namespace WarriorsAndMagesRPG.Core
{
    public class Controller : IController
    {
        IPrinterService _printerService;
        IReaderService _readerService;

        WarriorsAndMagesContext _context;

        public Controller(IPrinterService printerService, IReaderService readerService, WarriorsAndMagesContext context)
        {
            _printerService = printerService;
            _readerService = readerService;
            _context = context;
        }

        public int AddStatsToCharacter(Models.Character character, string statName, int points)
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
                    case nameof(Character.Strength):
                        character.Strength += pointsToAdd;
                        break;
                    case nameof(Character.Agility):
                        character.Agility += pointsToAdd;
                        break;
                    case nameof(Character.Intelligence):
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

        public void LogCharacter(Models.Character characterViewModel)
        {
            Infrastructure.Models.CharacterEntity character = CharacterMapper.ToCharacter(characterViewModel);
            _context.Characters.Add(character);

            _context.SaveChanges();
        }
    }
}
