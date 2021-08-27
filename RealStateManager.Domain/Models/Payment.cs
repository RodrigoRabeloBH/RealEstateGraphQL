using System;
using System.Text.Json.Serialization;

namespace RealStateManager.Domain.Models
{
    public class Payment : Entity
    {
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OverdueDate { get; set; }
        public bool Paid { get; set; }
        public int PropertyId { get; set; }

        [JsonIgnore]
        public Property Property { get; set; }
    }
}
