using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.Types
{
    public class TypeRepository : SqlRepository<Pokedex.Models.Type>, ITypeRepository
    {
        public TypeRepository(PokedexDBContext context) : base(context)
        {
        }
    }
}
