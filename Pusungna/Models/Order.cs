using System;
using System.Collections.Generic;

namespace Pusungna.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
