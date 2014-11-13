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
        public string Name { get; set; }
    }

    public class CreateEventResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
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