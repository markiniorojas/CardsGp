using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.@interface
{
    public abstract class  ABaseModelData<T> : IBaseModelData<T> where T : BaseModel 
    {
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<T> GetById(int id);
        public abstract Task<T> Create(T entity);
        public abstract Task<T> Update(T entity);
        public abstract Task<bool> deleteLogico(int id);

    }
}
