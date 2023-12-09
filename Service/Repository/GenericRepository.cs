using Core.Enums;
using Core.Models.Shared;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interface.Repository;

namespace Services.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null) throw new InvalidOperationException("Cannot add a null object!");
            entity.CreatedDateT = DateTime.UtcNow;
            var dbEntity = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return dbEntity.Entity;
        }
        
        public T Add(T entity)
        {
            if (entity == null) throw new InvalidOperationException("Cannot add a null object!");
            entity.CreatedDateT = DateTime.UtcNow;
            var dbEntity = _context.Add(entity);
            _context.SaveChanges();
            return dbEntity.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new InvalidOperationException("Cannot delete a null object!");
            //We do a soft delete, just update it.
            entity.IsDeleted = true;
            entity.Status = Status.Deleted;
            entity.DeletedDateT = DateTime.UtcNow;
            await UpdateAsync(entity);
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity == null) throw new InvalidCastException("Cannot remove a null object");

            var fetchEntity = await _context.FindAsync<T>(entity.Id);

            if (fetchEntity != null) _context.Remove(fetchEntity);

            await _context.SaveChangesAsync();
        }
        
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new InvalidOperationException("Cannot update a null object!");
            entity.ModifiedDateT = DateTime.UtcNow;
            var dbEntity = _context.Update(entity); //No async update! Sad times.
            await _context.SaveChangesAsync();
            return dbEntity.Entity;
        }

        public T? GetById(string id)
        {
            //Weirdness with async methods here, just use sync.
            var entity = _context.Find<T>(id);
            return entity == null || entity.IsDeleted ? null : entity;
        }

        public T? GetById(int id)
        {
            //Weirdness with async methods here, just use sync.
            var entity = _context.Find<T>(id);
            return entity == null || entity.IsDeleted ? null : entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().Where(t => !t.IsDeleted).ToList();
        }
        
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(t => !t.IsDeleted).ToListAsync();
        }
    }