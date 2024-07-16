namespace WarriorsAndMagesRPG.Core.Models
{
    public abstract class CharacterViewModel
    {
        protected CharacterViewModel(int strength, int agility, int intelligence, int range, char characterSymbol) 
        {
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Range = range;
            CharacterSymbol = characterSymbol;
            DateCreated = DateTime.UtcNow;
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
                    return;
                case 'a':
                    return;
                case 's':
                    return;
                case 'd':
                    return;
                case 'e':
                    return;
                case 'x':
                    return;
                case 'q':
                    return;
                case 'z':
                    return;
            }
        }
    }
}
