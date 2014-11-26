using System;

namespace AngularServiceStackMongo.ServiceModel
{
    using AngularServiceStackMongo.Core;

    public class Event : IEvent, IIdentifiable<string>, IUser
    {
        public string UserName { get; set; }

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

        public string Id { get; set; }
    }
}
