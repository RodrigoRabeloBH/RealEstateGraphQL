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
    }
}
