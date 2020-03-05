using Pokedex.Data.Skills;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<bool> Delete(Skill skill)
        {
            return await _skillRepository.Delete(skill);
        }

        public async Task<List<Skill>> GetAll()
        {
            var skills = await _skillRepository.GetAll();
            return skills.ToList();
        }

        public async Task<Skill> GetById(int? id)
        {
            if (id.HasValue)
            {
                return await _skillRepository.GetById(id.Value);
            }
            return null;
        }

        public async Task<Skill> Insert(Skill skill)
        {
            return await _skillRepository.Insert(skill);
        }

        public async  Task<Skill> Update(Skill skill)
        {
            return await _skillRepository.Update(skill);
        }
    }
}
