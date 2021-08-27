using Microsoft.Extensions.Logging;
using RealStateManager.Domain.Interfaces;
using RealStateManager.Domain.Models;

namespace RealStateManager.Infrastructure.Repository
{
    public class PaymentRepository : RealStateRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(RealStateContext context, ILogger<RealStateRepository<Payment>> logger) : base(context, logger)
        {
        }
    }
}
