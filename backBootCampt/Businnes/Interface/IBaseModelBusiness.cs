using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IBaseModelBusiness<TEntity, TDto> where TDto : BaseDto where TEntity : BaseModel
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetById(int id);
        Task<TDto> Create(TDto entity);
        Task<bool> deleteLogico(int id);

    }
}
