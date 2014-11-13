namespace AngularServiceStackMongo.ServiceModel
{
    using System.Collections.Generic;
    using ServiceStack;

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
    public class CreateTimelineRequest : IReturn<CreateTimelineResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateTimelineResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
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