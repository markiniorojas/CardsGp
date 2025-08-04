using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.@interface
{
    public interface IBaseModelData<TEntity, TDto> where TEntity : BaseModel where TDto : BaseDto
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TEntity> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> deleteLogico(int id);
    }
}
