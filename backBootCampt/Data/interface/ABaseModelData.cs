using Data.@interface;
using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.@interface
{
    public abstract class  ABaseModelData<TEntity, TDto> : IBaseModelData<TEntity, TDto> 
        where TEntity : BaseModel
        where TDto : BaseDto
    {
        public abstract Task<IEnumerable<TDto>> GetAllAsync();
        public abstract Task<TEntity> GetById(int id);
        public abstract Task<TEntity> Create(TEntity entity);
        public abstract Task<TEntity> Update(TEntity entity);
        public abstract Task<bool> deleteLogico(int id);

    }
}
