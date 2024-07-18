using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Mage : Character
    {
        public Mage() : base(MAGE_STRENGTH, MAGE_AGILITY, MAGE_INTELLIGENCE, MAGE_RANGE, MAGE_SYMBOL, START_CHARACTER_POSX, START_CHARACTER_POSY) { }

        public int Mana { get; protected set; }

        public override void Setup()
        {
            this.Mana = this.Intelligence * 3;
            base.Setup();
        }

        public override void Attack(Character character)
        {
            if (Mana > 0)
            {
                Mana--;
                base.Attack(character);
            }
        }
    }
}
