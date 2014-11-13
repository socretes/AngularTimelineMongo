namespace AngularServiceStackMongo.Domain
{
    using System;
    using AngularServiceStackMongo.Core;
    using MongoDB.Bson;

    public interface IEntity : IIdentifiable<ObjectId>
    {
        ObjectId Id { get; set; }
        
        DateTime UpdatedDateTime { get; set; }
    }
}
