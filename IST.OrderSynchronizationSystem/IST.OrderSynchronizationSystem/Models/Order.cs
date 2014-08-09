using System;
using System.Collections.Generic;

namespace IST.OrderSynchronizationSystem.Models
{
    public sealed class Order
    {
        // ReSharper disable once InconsistentNaming
        public string OrderID { get; set; }
        public DateTime Orderdate { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // ReSharper disable once InconsistentNaming
        public int ShippingMethodID { get; set; }
        // ReSharper disable once InconsistentNaming
        public string CODAmount { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Custom5 { get; set; }
        public string Custom6 { get; set; }
        public List<OrderItem> Items { get; set; }


    }
}
