using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RealStateManager.Domain.Interfaces;
using RealStateManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealStateManager.Infrastructure.Repository
{
    public class RealStateRepository<T> : IRealStateRepository<T> where T : Entity
    {
        protected readonly RealStateContext _context;
        protected readonly ILogger<RealStateRepository<T>> _logger;

        public RealStateRepository(RealStateContext context, ILogger<RealStateRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                _context.Set<T>().Remove(await GetById(id));

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> entities = null;

            try
            {
                entities = await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return entities;
        }

        public async Task<T> GetById(int id)
        {
            T entity = null;

            try
            {
                entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return entity;
        }
        public async Task Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
