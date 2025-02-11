using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Driver
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<string> AssignedPackages { get; set; } = new();
}
