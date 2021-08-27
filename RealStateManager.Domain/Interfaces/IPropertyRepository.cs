using System.Collections.Generic;
using System.Threading.Tasks;
using RealStateManager.Domain.Models;

namespace RealStateManager.Domain.Interfaces
{
    public interface IPropertyRepository : IRealStateRepository<Property>
    {
        Task<IEnumerable<Property>> GetAllPropertiesWithPayments();

        Task<Property> GetByIdWithPayments(int id);
    }
}
