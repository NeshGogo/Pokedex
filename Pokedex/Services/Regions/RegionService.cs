using Pokedex.Data.Regions;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pokedex.Services.Regions
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService( IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        

        public async Task<bool> Delete(Region region)
        {
             return  await _regionRepository.Delete(region);            
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await _regionRepository.GetAll();
        }

        public async Task<Region> GetById(int? id)
        {
            if ( id.HasValue)
            {
                return await _regionRepository.GetById(id.Value);
            }
            return null;
        }

        public async Task<Region> Insert(Region region)
        {
            return await _regionRepository.Insert(region);
        }

        public async Task<Region> Update(Region region)
        {
            return await _regionRepository.Update(region);
        }

    }
}
