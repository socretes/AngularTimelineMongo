namespace AngularServiceStackMongo.ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ServiceStack;
    using AngularServiceStackMongo.ServiceModel;

    public class EventService : Service
    {
        private readonly AngularServiceStackMongo.Domain.EventRepository respository;

        public EventService()
        {
            respository = new AngularServiceStackMongo.Domain.EventRepository();
        }

        public Event Get(GetEvent request)
        {
            var entity = respository.Get(request.Id);
            var dto = entity.ConvertTo<Event>();

            return dto;
        }

        public CreateEventResponse Post(CreateEvent request)
        {
            var entity = request.ConvertTo<Domain.Event>();
            var requestId = respository.SaveUpdate(entity);

            return new CreateEventResponse() { Id = requestId };
        }

        public DeleteEventResponse Delete(DeleteEvent request)
        {
            respository.Delete(request.Id);

            return new DeleteEventResponse() { Id = request.Id };
        }
    }
}

