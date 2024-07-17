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
            switch (Char.ToLower(key))
            {
                case 'w':
                    PosX -= Range;
                    return;
                case 'a':
                    PosY -= Range;
                    return;
                case 's':
                    PosX += Range;
                    return;
                case 'd':
                    PosY += Range;
                    return;
                case 'e':
                    PosX -= Range;
                    PosY += Range;
                    return;
                case 'x':
                    PosX += Range;
                    PosY += Range;
                    return;
                case 'q':
                    PosX -= Range;
                    PosY -= Range;
                    return;
                case 'z':
                    PosX -= Range;
                    PosY -= Range;
                    return;
            }
        }
    }
}
