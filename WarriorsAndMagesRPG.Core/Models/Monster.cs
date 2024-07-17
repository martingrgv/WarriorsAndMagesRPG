using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Monster : CharacterViewModel
    {
        public Monster() : base(GetRandomStats(), GetRandomStats(), GetRandomStats(), MONSTER_RANGE, MONSTER_SYMBOL, GetRandomPos(), GetRandomPos())
        {
            base.Setup();
        }

        private static int GetRandomStats()
        {
            Random rnd = new Random();
            return rnd.Next(MONSTER_STATUS_MIN_RANDOM, MONSTER_STATUS_MAX_RANDOM);
        }

        private static int GetRandomPos()
        {
            Random rnd = new Random();
            return rnd.Next(0, GAME_FIELD_SIZE);
        }
    }
}
