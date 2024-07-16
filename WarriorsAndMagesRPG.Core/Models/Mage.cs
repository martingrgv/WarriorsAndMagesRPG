using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Mage : Character
    {
        public Mage()
        {
            CharacterSymbol = DEFAULT_MAGE_SYMBOL;
        }

        public int Mana { get; set; }

        public override void Setup()
        {
            this.Mana = this.Intelligence * 3;
            base.Setup();
        }
    }
}
