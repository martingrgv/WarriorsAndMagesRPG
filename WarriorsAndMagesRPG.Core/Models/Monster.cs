using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Monster : Character
    {
        public Monster() : base (GetRandom(), GetRandom(), GetRandom(), MONSTER_RANGE, MONSTER_SYMBOL) { }

        private static int GetRandom()
        {
            Random rnd = new Random();
            return rnd.Next(MONSTER_STATUS_MIN_RANDOM, MONSTER_STATUS_MAX_RANDOM);
        }
    }
}
