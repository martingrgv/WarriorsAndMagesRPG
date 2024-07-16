using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Archer : CharacterViewModel
    {
        public Archer() : base(ARCHER_STRENGTH, ARCHER_AGILITY, ARCHER_INTELLIGENCE, ARCHER_RANGE, ARCHER_SYMBOL) { }
    }
}
