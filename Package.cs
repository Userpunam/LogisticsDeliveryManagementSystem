using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using LogisticsDeliveryManagementSystem.Models;


public class Package
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string RecipientName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public Dimensions Dimensions { get; set; }
    public PackageStatus Status { get; set; } = PackageStatus.Pending;
    public string? AssignedDriverID { get; set; }
}

