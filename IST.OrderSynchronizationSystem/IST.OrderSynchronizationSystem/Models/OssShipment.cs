using System;
using System.Runtime.Serialization;
using IST.OrderSynchronizationSystem.MBAPI;

namespace IST.OrderSynchronizationSystem.Models
{
    [Serializable]
    public class OssShipment: Shipment
    {
        [DataMemberAttribute]
        public Int64 ThubOrderId { get; set; }
        [DataMemberAttribute]
        public string WebShipMethod { get; set; }
    }
}
