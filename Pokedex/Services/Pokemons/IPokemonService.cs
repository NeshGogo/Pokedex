using Pokedex.Models;
using Pokedex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pokedex.Services.Pokemons
{
    public interface IPokemonService
    {
        public Task<IEnumerable<Pokemon>> GetAll();
        public Task<Pokemon> GetById(int? id);
        public Task<Pokemon> Insert(Pokemon pokemon, List<int> skills, List<int> types);
        public Task<Pokemon> Update(Pokemon pokemon, List<int> skills, List<int> types);
        public Task<bool> Delete(Pokemon pokemon);
        public Task<IEnumerable<Pokemon>> Where(Expression<Func<Pokemon,bool>> filter);
        public Task<Pokemon> GetByIdFull(int? id);
        public Task<List<Pokemon>> GetAllWithRegion();

    }
}
