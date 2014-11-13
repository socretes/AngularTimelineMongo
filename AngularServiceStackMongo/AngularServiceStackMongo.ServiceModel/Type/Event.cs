namespace AngularServiceStackMongo.ServiceModel
{
    using AngularServiceStackMongo.Core;

    public class Event : IEvent, IIdentifiable<string>, IUser
    {
        public string EventId { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
