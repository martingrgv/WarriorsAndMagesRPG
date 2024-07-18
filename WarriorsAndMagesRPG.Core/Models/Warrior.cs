using static WarriorsAndMagesRPG.Core.Common.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Warrior : Character
    {
        public Warrior() : base(WARRIOR_STRENGTH, WARRIOR_AGILITY, WARRIOR_INTELLIGENCE, WARRIOR_RANGE, WARRIOR_SYMBOL, START_CHARACTER_POSX, START_CHARACTER_POSY) { }
    }
}
