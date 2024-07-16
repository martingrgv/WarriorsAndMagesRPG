using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WarriorsAndMagesRPG.Infrastructure.Models.Enums;

namespace WarriorsAndMagesRPG.Infrastructure.Models
{
    public class Character
    {
        [Key]
        [Comment("Identity key")]
        public int Id { get; set; }

        [Required]
        [Comment("Character class enum")]
        public CharacterClass CharacterClass { get; set; }

        [Required]
        [Comment("Character health")]
        public int Health { get; set; }

        [Required]
        [Comment("Character strength")]
        public int Strength { get; set; }

        [Required]
        [Comment("Character agility")]
        public int Agility { get; set; }
        
        [Required]
        [Comment("Character intelligence")]
        public int Intelligence { get; set; }

        [Required]
        [Comment("Character damage")]
        public int Damage { get; set; }

        [Required]
        [Comment("Character range")]
        public int Range { get; set; }

        [Required]
        [Comment("Character symbol")]
        public char CharacterSymbol { get; protected set; }

        [Required]
        [Comment("Date of character creation")]
        public DateTime DateCreated { get; set; }
    }
}
