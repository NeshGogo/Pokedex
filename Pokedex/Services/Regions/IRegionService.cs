using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pokedex.Services.Regions
{
    public interface IRegionService
    {
        public Task<List<Region>> GetAll();
        public Task<Region> GetById(int? id);
        public Task<Region> Insert(Region region);
        public Task<Region> Update(Region region);
        public Task<bool> Delete(Region region);
    }
}
