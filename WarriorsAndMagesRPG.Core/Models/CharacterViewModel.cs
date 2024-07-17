using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Models
{
    public abstract class CharacterViewModel
    {
        protected CharacterViewModel(int strength, int agility, int intelligence, int range, char characterSymbol, int startPosX, int startPosY) 
        {
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Range = range;
            CharacterSymbol = characterSymbol;
            DateCreated = DateTime.UtcNow;
            PosX = startPosX;
            PosY = startPosY;
        }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public char CharacterSymbol { get; protected set; }
        public DateTime DateCreated { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }

        public virtual void Setup()
        {
            this.Health = this.Strength * 5;
            this.Damage = this.Agility * 2;
        }

        public void Attack(CharacterViewModel monster)
        {
            monster.Health -= this.Strength;
        }

        public void Move(char key)
        {
            int newPosX = PosX;
            int newPosY = PosY;

            switch (char.ToLower(key))
            {
                case 'w':
                    newPosY = PosY - Range;
                    break;
                case 'a':
                    newPosX = PosX - Range;
                    break;
                case 's':
                    newPosY = PosY + Range;
                    break;
                case 'd':
                    newPosX = PosX + Range;
                    break;
                case 'e':
                    newPosX = PosX + Range;
                    newPosY = PosY - Range;
                    break;
                case 'x':
                    newPosX = PosX + Range;
                    newPosY = PosY + Range;
                    break;
                case 'q':
                    newPosX = PosX - Range;
                    newPosY = PosY - Range;
                    break;
                case 'z':
                    newPosX = PosX - Range;
                    newPosY = PosY + Range;
                    break;
            }

            if (newPosX < 0 || newPosX >= GAME_FIELD_SIZE||
                newPosY < 0 || newPosY >= GAME_FIELD_SIZE)
            {
                throw new InvalidOperationException("Cannot move outside of boundries");
            }

            PosX = newPosX;
            PosY = newPosY;
        }
    }
}
