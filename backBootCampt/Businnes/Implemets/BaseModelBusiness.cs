using Business.Interface;
using Data;
using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implemets
{
    public class ConcreteModelBusiness<T> : ABaseModelBusiness<T> where T : BaseModel
    {
        private readonly BaseModelData<T> _repository; 

        public ConcreteModelBusiness(BaseModelData<T> repository)
        {
            _repository = repository;
        }

        public override async Task<IEnumerable<T>> GetAllAsync()
        {
           
            return await _repository.GetAllAsync();
        }

        public override async Task<T> GetById(int id)
        {
           
            return await _repository.GetById(id);
        }

        public override async Task<T> Create(T entity)
        {
          
            return await _repository.Create(entity);
        }

        public override async Task<bool> deleteLogico(int id)
        {
           
            var entityToDelete = await _repository.GetById(id);
            if (entityToDelete != null)
            {
                entityToDelete.isDeleted = false;
                await _repository.Update(entityToDelete);
                return true;
            }
            return false;
        }
    }
}
