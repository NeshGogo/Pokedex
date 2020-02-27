using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.Regions
{
    public class RegionRepositorycs : SqlRepository<Region>, IRegionRepository
    {
        public RegionRepositorycs(PokedexDBContext context) : base(context)
        {
        }
    }
}
