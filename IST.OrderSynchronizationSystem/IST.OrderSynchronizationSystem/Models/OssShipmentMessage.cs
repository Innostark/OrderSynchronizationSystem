using IST.OrderSynchronizationSystem.MBAPI;

namespace IST.OrderSynchronizationSystem.Models
{
    internal class OssShipmentMessage
    {
        public string ApiKey { get; set; }

        public Shipment[] Shipments { get; set; }

        public OssShipmentMessage(string apiKey, Shipment[] shipments)
        {
            this.ApiKey = apiKey;
            this.Shipments = shipments;
        }
    }
}
