namespace AngularServiceStackMongo.Domain
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using AngularServiceStackMongo.Core;

    public class MongoEntity : IEntity, IUser, IIdentifiable<ObjectId>
    {
        public MongoEntity(string userName)
        {
            this.UserName = userName;
            this.UpdatedDateTime = DateTime.Now;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public System.DateTime UpdatedDateTime { get; set; }

        public string UserName { get; set; }
    }
}
