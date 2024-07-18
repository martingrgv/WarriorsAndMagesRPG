using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Infrastructure.Models;
using WarriorsAndMagesRPG.Infrastructure.Models.Enums;

namespace WarriorsAndMagesRPG.Core.Utilities
{
    public class CharacterMapper
    {
        public static CharacterEntity ToCharacter(Character characterViewModel)
        {
            var characterClass = GetCharacterClass(characterViewModel);

            return new CharacterEntity
            {
                CharacterClass = characterClass,
                Health = characterViewModel.Health,
                Strength = characterViewModel.Strength,
                Agility = characterViewModel.Agility,
                Intelligence = characterViewModel.Intelligence,
                Damage = characterViewModel.Damage,
                Range = characterViewModel.Range,
                CharacterSymbol = characterViewModel.CharacterSymbol,
                DateCreated = characterViewModel.DateCreated
            };
        }

        private static CharacterClass GetCharacterClass(Character characterViewModel)
        {
            if (characterViewModel is Warrior)
            {
                return CharacterClass.Warrior;
            }
            else if (characterViewModel is Mage)
            {
                return CharacterClass.Mage;
            }
            else if (characterViewModel is Archer)
            {
                return CharacterClass.Archer;
            }

            throw new InvalidOperationException("Could not convert character class!");
        }
    }
}
