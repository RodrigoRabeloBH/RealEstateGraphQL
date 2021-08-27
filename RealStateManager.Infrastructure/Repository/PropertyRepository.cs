using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RealStateManager.Domain.Interfaces;
using RealStateManager.Domain.Models;

namespace RealStateManager.Infrastructure.Repository
{
    public class PropertyRepository : RealStateRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(RealStateContext context, ILogger<RealStateRepository<Property>> logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesWithPayments()
        {
            IEnumerable<Property> properties = null;

            try
            {
                properties = await _context.Properties
                .AsNoTracking()
                .Include(p => p.Payments)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return properties;
        }

        public async Task<Property> GetByIdWithPayments(int id)
        {
            Property property = null;

            try
            {
                property = await _context.Properties
                .AsNoTracking()
                .Include(p => p.Payments)
                .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return property;
        }
    }
}
