using AutoMapper;
using Business.Interface;
using Data;
using Data.@interface;
using Entity.Base;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implemets
{
    public class BaseModelBusiness<TEntity, TDto> : ABaseModelBusiness<TEntity, TDto>
     where TEntity : BaseModel
     where TDto : BaseDto
    {
        private readonly IBaseModelData<TEntity, TDto> _repository;
        private readonly IMapper _mapper;

        public BaseModelBusiness(IBaseModelData<TEntity, TDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<IEnumerable<TDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync(); // ✅ Correcto: ya devuelve DTOs
        }

        public override async Task<TDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            return _mapper.Map<TDto>(entity);
        }

        public override async Task<TDto> Create(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.isDeleted = false;
            var createdEntity = await _repository.Create(entity);
            return _mapper.Map<TDto>(createdEntity);
        }

        public override async Task<bool> deleteLogico(int id)
        {
            return await _repository.deleteLogico(id);
        }
    }

}
