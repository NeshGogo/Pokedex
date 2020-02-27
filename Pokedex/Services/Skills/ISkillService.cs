using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Services.Skills
{
    public interface ISkillService
    {
        public Task<IEnumerable<Skill>> GetAll();
        public Task<Skill> GetById(int? id);
        public Task<Skill> Insert(Skill skill);
        public Task<Skill> Update(Skill skill);
        public Task<bool> Delete(Skill skill);
    }
}
