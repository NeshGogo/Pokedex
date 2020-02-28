using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Services.Types
{
    public interface ITypeService
    {
        public Task<IEnumerable<Pokedex.Models.Type>> GetAll();
        public Task<Pokedex.Models.Type> GetById(int? id);
        public Task<Pokedex.Models.Type> Insert(Pokedex.Models.Type type);
        public Task<Pokedex.Models.Type> Update(Pokedex.Models.Type type);
        public Task<bool> Delete(Pokedex.Models.Type type);
    }
}
