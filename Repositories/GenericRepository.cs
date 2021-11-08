using Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        ITIDBContext Context;
        DbSet<T> Table;
        public GenericRepository(ITIDBContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAsync()
        {
            return Table;
        }
        public async Task<T> GetByIDAsync(int Id)
        {
            return await Table.FindAsync(Id);
        }
        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            Table.Update(entity);
            return entity;
        }
        public async Task<T> UpdatePatch(int id,JsonPatchDocument entity)
        {
            T Temp = await Table.FindAsync(id);
            entity.ApplyTo(Temp);
            return Temp;
        }
        public async Task<T> Remove(T entity)
        {
            Table.Remove(entity);
            return entity;
        }
    }
}
