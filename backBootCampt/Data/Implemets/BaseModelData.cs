using Data.@interface;
using Entity.Base;
using Entity.dbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data
{
        public class BaseModelData<T> : ABaseModelData<T> where T : BaseModel
        {
            private readonly ApplicationDbContext _context;

            public BaseModelData(ApplicationDbContext context)
            {
                _context = context;
            }

            public override async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _context.Set<T>()
                                     .Where(e => !e.isDeleted) 
                                     .ToListAsync();
            }

            public override async Task<T> GetById(int id)
            {
                return await _context.Set<T>().FirstOrDefaultAsync(e => e.id == id && !e.isDeleted); 
            }

            public override async Task<T> Create(T entity)
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            public override async Task<T> Update(T entity)
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }

        public override async Task<bool> deleteLogico(int id)
            {

                var entityToDelete = await _context.Set<T>().FirstOrDefaultAsync(e => e.id == id);
                if (entityToDelete == null)
                {
                    return false; 
                }

                entityToDelete.isDeleted = true; 
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
