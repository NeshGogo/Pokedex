using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pokedex.Services.Pokemons
{
    interface IPokemonService
    {
        public Task<IEnumerable<Pokemon>> GetAll();
        public Task<Pokemon> GetById(int? id);
        public Task<Pokemon> Insert(Pokemon pokemon);
        public Task<Pokemon> Update(Pokemon pokemon);
        public Task<bool> Delete(Pokemon pokemon);
        public Task<IEnumerable<Pokemon>> Where(Expression<Func<Pokemon,bool>> filter);

    }
}
