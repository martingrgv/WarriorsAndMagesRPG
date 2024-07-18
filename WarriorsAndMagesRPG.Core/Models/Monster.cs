using static WarriorsAndMagesRPG.Core.Common.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public class Monster : Character
    {
        public Monster() : base(GetRandomStats(), GetRandomStats(), GetRandomStats(), MONSTER_RANGE, MONSTER_SYMBOL, GetRandomPos(), GetRandomPos())
        {
            base.Setup();
        }

        public override void Attack(Character character)
        {
            if (CharacterInAttackRange(this, character))
            {
                character.Health -= this.Strength;
                return;
            }
        }

        public void FollowCharacter(Character character)
        {
            if (this.PosX < character.PosX - 1) this.PosX++;
            else if (this.PosX > character.PosX + 1) this.PosX--;
            
            if (this.PosY < character.PosY - 1) this.PosY++;
            else if (this.PosY > character.PosY + 1) this.PosY--;
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
