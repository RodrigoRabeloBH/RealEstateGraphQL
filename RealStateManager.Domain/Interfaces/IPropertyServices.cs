using System.Collections.Generic;
using System.Threading.Tasks;
using RealStateManager.Domain.Models;

namespace RealStateManager.Domain.Interfaces
{
    public interface IPropertyServices
    {
        Task<IEnumerable<Property>> GetAllPropertiesWithPayments();
        Task<IEnumerable<Property>> GetAll();
        Task<Property> GetByIdWithPayments(int id);
        Task<Property> GetById(int id);
        Task Remove(int id);
        Task Create(Property property);
        Task Update(Property property);
    }
}