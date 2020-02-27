using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data
{
    interface IRepository<T> where T: class
    {
       public Task<IEnumerable<T>> GetAll();
       public Task<T> GetById(int id);
       public Task<T> Insert(T entity);
       public Task<IEnumerable<T>> InsertRage(IEnumerable<T> entities);
       public Task<T> Update(T entity);
       public Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities);

       public Task<bool> Delete(T entity);
       public Task<bool> DeleteRange(IEnumerable<T> entities);

    }
}
