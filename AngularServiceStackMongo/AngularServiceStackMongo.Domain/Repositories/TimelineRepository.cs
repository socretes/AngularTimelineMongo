namespace AngularServiceStackMongo.Domain
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Driver.Builders;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class TimelineRepository : EntityRepository<Timeline>
    {
        public IEnumerable<Timeline> GetAll()
        {
            var result = this.MongoConnectionHandler.MongoCollection.FindAll()
                        .SetSortOrder(SortBy<Timeline>.Ascending(p => p.Name));

            return result;
        }

        public IEnumerable<Timeline> GetByName(string name) //, int limit, int skip)
        {
            var entityQuery = Query<Timeline>.EQ(e => e.Name, name);

            var result = this.MongoConnectionHandler.MongoCollection.Find(entityQuery);
                        //.SetSortOrder(SortBy<Timeline>.Ascending(p => p.Name))
                        //.SetLimit(limit)
                        //.SetSkip(skip);

            return result;
        }

        public IEnumerable<Timeline> GetTimelinesByUser(string userName, int limit, int skip)
        {
            var entityQuery = Query<Timeline>.EQ(e => e.UserName, userName);

            var result = this.MongoConnectionHandler.MongoCollection.Find(entityQuery)
                .SetSortOrder(SortBy<Timeline>.Ascending(p => p.Name))
                .SetLimit(limit)
                .SetSkip(skip);

            return result;
        }
    }
}
