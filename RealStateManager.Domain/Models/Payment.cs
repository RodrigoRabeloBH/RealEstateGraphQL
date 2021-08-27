using System;

namespace RealStateManager.Domain.Models
{
    public class Payment : Entity
    {
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OverdueDate { get; set; }
        public bool Paid { get; set; }
    }
}
