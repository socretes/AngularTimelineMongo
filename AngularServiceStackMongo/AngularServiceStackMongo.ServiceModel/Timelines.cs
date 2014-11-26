namespace AngularServiceStackMongo.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using ServiceStack;
    using AngularServiceStackMongo.Core;

    [Route("/timeline", "GET")]
    public class FindTimelines : IReturn<List<Timeline>>
    {
        public string Name { get; set; }
    }
    
    [Route("/timeline/{Id}", "GET")]
    public class GetTimeline : IReturn<Timeline>
    {
        public string Id { get; set; }
    }

    [Route("/timeline", "POST")]
    public class CreateTimelineRequest : IReturn<CreateTimelineResponse>, ITimeline
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Media { get; set; }
        public string Credit { get; set; }
        public string Caption { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class CreateTimelineResponse : ITimeline
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Media { get; set; }
        public string Credit { get; set; }
        public string Caption { get; set; }
        public DateTime StartDate { get; set; }
        public ResponseStatus ResponseStatus { get; set; } //TODO: Determine if this is giving me anything!
    }

    [Route("/timeline/{Id}", "DELETE")]
    public class DeleteTimeline
    {
        public string Id { get; set; }
    }

    public class DeleteTimelineResponse
    {
        public string Id { get; set; }
        public ResponseStatus ResponseStatus { get; set; } //TODO: Determine if this is giving me anything!
    }
}