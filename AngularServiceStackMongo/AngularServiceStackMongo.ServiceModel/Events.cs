using System;

namespace AngularServiceStackMongo.ServiceModel
{
    using System.Collections.Generic;
    using ServiceStack;

    [Route("/event/{Id}", "GET")]
    public class GetEvent : IReturn<Event>
    {
        public string Id { get; set; }
    }

    [Route("/event", "POST")]
    public class CreateEvent : IReturn<CreateEventResponse>
    {
        public string Id { get; set; }
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
    }

    public class CreateEventResponse
    {
        public string Id { get; set; }
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
        public ResponseStatus ResponseStatus { get; set; }
    }

    [Route("/event/{Id}", "DELETE")]
    public class DeleteEvent
    {
        public string Id { get; set; }
    }

    public class DeleteEventResponse
    {
        public string Id { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}