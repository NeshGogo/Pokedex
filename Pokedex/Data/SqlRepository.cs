using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private readonly PokedexDBContext _context;
        private DbSet<T> _entities;
        public virtual DbSet<T> Entities 
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }

        public SqlRepository(PokedexDBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await Entities.ToListAsync();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await Entities.FindAsync(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public  async Task<T> Insert(T entity)
        {
            try
            {
                await Entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }                   
        }

        public async Task<IEnumerable<T>> InsertRage(IEnumerable<T> entities)
        {
            try
            {
                await Entities.AddRangeAsync(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                Entities.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                Entities.UpdateRange(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> Delete(T entity)
        {
            try
            {
                Entities.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public async Task<bool> DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                Entities.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
