using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Warrior : Character
    {
        public Warrior() : base(WARRIOR_STRENGTH, WARRIOR_AGILITY, WARRIOR_INTELLIGENCE, WARRIOR_SYMBOL) { }
    }
}
