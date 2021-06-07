using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Application.Interfaces
{
    public interface IGenericService<T, TBase, TKey> : IMainService<T, TKey>
        where T : TBase
         where TKey : IEquatable<TKey>
    {
        
    }
}
