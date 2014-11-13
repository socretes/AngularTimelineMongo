namespace AngularServiceStackMongo.Domain
{
    using System;
    using AngularServiceStackMongo.Core;
    
    public class Event : MongoEntity, IEvent
    {
        public Event(string timelineId, string name, string userName)
            : base(userName)
        {
            this.TimelineId = timelineId;
            this.Name = name;
        }

        public string Name { get; set; }

        public string TimelineId { get; set; }
    }
}
