namespace AngularServiceStackMongo.ServiceModel
{
    using AngularServiceStackMongo.Core;
    
    public class Timeline : ITimeline, IIdentifiable<string>, IUser
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
