using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace file_service.Models;

public class File
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public int Id { get; set; }

    [BsonElement("username")]
    public string Username { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    //location of file in Firebase or whatever file storage will be used
    [BsonElement("location")]
    public string Location { get; set; }
}