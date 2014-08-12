using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IST.OrderSynchronizationSystem.MBAPI;

namespace IST.OrderSynchronizationSystem.Models
{
    public class OssShipment: Shipment
    {
        public Int64 ThubOrderId { get; set; }
    }
}
