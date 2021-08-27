using RealStateManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealStateManager.Domain.Interfaces
{
    public interface IRealStateRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
