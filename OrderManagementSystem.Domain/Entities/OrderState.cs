﻿namespace OrderManagementSystem.Domain
{
    public partial class OrderState
    {
        public OrderState()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStateId { get; set; }
        public string State { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
