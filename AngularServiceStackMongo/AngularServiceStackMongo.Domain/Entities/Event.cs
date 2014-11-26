namespace AngularServiceStackMongo.Domain
{
    using System;
    using AngularServiceStackMongo.Core;
    
    public class Event : MongoEntity, IEvent
    {
        public Event(string timelineId, string headline, DateTime startDate, DateTime endDate, string userName)
            : base(userName)
        {
            this.TimelineId = timelineId;
            this.Headline = headline;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public string TimelineId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Headline { get; set; }

        public string Text { get; set; }

        public string Media { get; set; }

        public string MediaCredit { get; set; }

        public string MediaCaption { get; set; }

        public string MediaThumbnail { get; set; }

        public string Type { get; set; }

        public string Tag { get; set; }
    }
}
