using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Application.Interfaces
{
    public interface IMainService<T, TKey> 
        where TKey : IEquatable<TKey>
    {
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<List<T>> GetAll();
        public Task<bool> Delete(TKey id);
        public Task<T> GetById(TKey id);
    }
}
