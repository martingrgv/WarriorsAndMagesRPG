using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Mage : Character
    {
        public Mage() : base(MAGE_STRENGTH, MAGE_AGILITY, MAGE_INTELLIGENCE, MAGE_SYMBOL) { }

        public int Mana { get; protected set; }

        public override void Setup()
        {
            this.Mana = this.Intelligence * 3;
            base.Setup();
        }
    }
}
