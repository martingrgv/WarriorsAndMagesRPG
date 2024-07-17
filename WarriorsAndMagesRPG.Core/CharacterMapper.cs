using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Infrastructure.Models;
using WarriorsAndMagesRPG.Infrastructure.Models.Enums;

namespace WarriorsAndMagesRPG.Core
{
    public class CharacterMapper
    {
        public static Infrastructure.Models.CharacterEntity ToCharacter(Models.Character characterViewModel)
        {
            var characterClass = GetCharacterClass(characterViewModel);

            return new Infrastructure.Models.CharacterEntity
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

        private static CharacterClass GetCharacterClass(Models.Character characterViewModel)
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
