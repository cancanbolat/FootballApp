using AutoMapper;
using Football.Application.Interfaces;
using Football.Core.Common;
using Football.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Infrastructure.Persistence.Services
{
    public class PlayerUserGenericService<T> : IGenericService<T, BaseModel, Guid>
        where T : BaseModel
    {
        private readonly FootballDbContext dbContext;

        public PlayerUserGenericService(FootballDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Delete(Guid id)
        {
            var dbEntity = await dbContext.Set<T>().Where(i => i.Id == id).FirstOrDefaultAsync();

            if (dbEntity == null)
                throw new Exception("Not found");

            dbContext.Set<T>().Remove(dbEntity);
            int result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbContext.Set<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            var dbEntity = await dbContext.Set<T>().Where(i => i.Id == entity.Id).FirstOrDefaultAsync();

            if (dbEntity == null)
                throw new Exception("Not found");

            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return dbEntity;
        }
    }
}
