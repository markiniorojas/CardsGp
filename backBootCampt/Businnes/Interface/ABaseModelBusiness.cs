using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public abstract class ABaseModelBusiness<T,D> : IBaseModelBusiness<T,D> where D : BaseDto where T : BaseModel
    {
        public abstract Task<IEnumerable<D>> GetAllAsync();
        public abstract Task<D> GetById(int id);
        public abstract Task<D> Create(D entity);
        public abstract Task<bool> deleteLogico(int id);
    }
}
