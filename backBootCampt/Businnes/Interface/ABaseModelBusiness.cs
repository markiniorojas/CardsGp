using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public abstract class ABaseModelBusiness<T> : IBaseModelBusiness<T> where T : BaseModel
    {
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<T> GetById(int id);
        public abstract Task<T> Create(T entity);
        public abstract Task<bool> deleteLogico(int id);
    }
}
