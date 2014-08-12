using IST.OrderSynchronizationSystem.MBAPI;

namespace IST.OrderSynchronizationSystem.MoldingBox
{
    public sealed class MoldingBoxHelper
    {
        public static MBAPISoapClient GetMoldingBoxClient()
        {
            return new MBAPISoapClient();;
        }

        public static Response[] PostShipment(MBAPISoapClient client, string apiKey, Shipment[] shipments)
        {
            return client.Post_Shipment(apiKey, shipments);
        }
    }
}
