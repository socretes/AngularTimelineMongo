namespace AngularServiceStackMongo.Domain
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public abstract class EntityRepository<T> : IEntityRepository<T> where T : IEntity
    {
        protected readonly MongoConnectionHandler<T> MongoConnectionHandler;
    
        protected EntityRepository()
        {
            MongoConnectionHandler = new MongoConnectionHandler<T>();
        }

        public virtual string SaveUpdate(T entity)
        {
            //// Save the entity with safe mode (WriteConcern.Acknowledged)
            var result = this.MongoConnectionHandler.MongoCollection.Save(
                entity,
                new MongoInsertOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });

            if (!result.Ok)
            {
                throw new Exception("Error saving or updating entity");
            }

            return entity.Id.ToString();
        }

        public virtual void Delete(string id)
        {
            var result = this.MongoConnectionHandler.MongoCollection.Remove(
                Query<T>.EQ(e => e.Id,
                new ObjectId(id)),
                RemoveFlags.None,
                WriteConcern.Acknowledged);

            if (!result.Ok)
            {
                throw new Exception("Error deleting entity");
            }
        }

        public virtual T Get(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoConnectionHandler.MongoCollection.FindOne(entityQuery);
        }
    }
}
