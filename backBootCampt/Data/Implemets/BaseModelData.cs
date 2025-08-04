using AutoMapper;
using Data.@interface;
using Entity.Base;
using Entity.dbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class BaseModelData<TEntity, TDto> : ABaseModelData<TEntity, TDto>
        where TEntity : BaseModel
        where TDto : BaseDto
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseModelData(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
        }

        public override async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _dbSet
                .Where(e => !e.isDeleted)
                .AsNoTracking()
                .ToListAsync();

            var dtoList = new List<TDto>();
            foreach (var entity in entities)
            {
                dtoList.Add(_mapper.Map<TDto>(entity));
            }

            return dtoList;
        }

        public override async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.id == id && !e.isDeleted);
        }

        public override async Task<TEntity> Create(TEntity entity)
        {
            entity.isDeleted = false;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<TEntity> Update(TEntity entity)
        {
            var existingEntity = await _dbSet.FindAsync(entity.id);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<bool> deleteLogico(int id)
        {
            var entity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.id == id);
            if (entity == null)
                return false;

            entity.isDeleted = true;
            await Update(entity);
            return true;
        }
    }
}
