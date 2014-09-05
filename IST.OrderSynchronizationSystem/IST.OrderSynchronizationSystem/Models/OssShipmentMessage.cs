namespace IST.OrderSynchronizationSystem.Models
{
    internal class OssShipmentMessage
    {
        public string ApiKey { get; set; }

        public OssShipment[] Shipments { get; set; }

        public OssShipmentMessage(string apiKey, OssShipment[] shipments)
        {
            ApiKey = apiKey;
            Shipments = shipments;
        }
    }
}
