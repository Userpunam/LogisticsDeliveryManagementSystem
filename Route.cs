using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using LogisticsDeliveryManagementSystem.Models;

public class Route
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string DriverID { get; set; }
    public List<string> PackageIDs { get; set; } = new();
    public RouteStatus Status { get; set; } = RouteStatus.Pending;
    public double Distance { get; set; }
}
