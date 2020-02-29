using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data
{
    public class PokedexDBContext: DbContext
    {

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonSkill> PokemonSkills { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Pokedex.Models.Type> Types { get; set; }

        public PokedexDBContext(DbContextOptions<PokedexDBContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonSkill>().HasKey(p => new { p.PokemonId, p.SkillId });
            modelBuilder.Entity<PokemonType>().HasKey(p => new { p.PokemonId, p.TypeId });

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
