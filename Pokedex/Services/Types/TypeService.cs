using Pokedex.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Services.Types
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public Task<bool> Delete(Models.Type type)
        {
            return _typeRepository.Delete(type);
        }

        public async Task<List<Models.Type>> GetAll()
        {
            var types = await _typeRepository.GetAll();
            return types.ToList();
        }

        public Task<Models.Type> GetById(int? id)
        {
            if (id.HasValue)
            {
                return _typeRepository.GetById(id.Value);
            }
            return null;
        }

        public Task<Models.Type> Insert(Models.Type type)
        {
            return _typeRepository.Insert(type);
        }

        public Task<Models.Type> Update(Models.Type type)
        {
            return _typeRepository.Update(type);
        }
    }
}
