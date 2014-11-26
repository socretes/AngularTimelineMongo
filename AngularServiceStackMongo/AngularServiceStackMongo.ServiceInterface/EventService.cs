namespace AngularServiceStackMongo.ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ServiceStack;
    using AngularServiceStackMongo.ServiceModel;

    public class EventService : Service
    {
        private readonly AngularServiceStackMongo.Domain.EventRepository repository;

        public EventService(AngularServiceStackMongo.Domain.EventRepository repositor)
        {
            this.repository = new AngularServiceStackMongo.Domain.EventRepository();
        }

        public List<Event> Get(FindEvents request)
        {            
            var timelines = repository.GetByTimelineId(request.TimelineId, 100, 0).ToList();
            var dto = timelines.ConvertAll(x => x.ConvertTo<Event>());
            return dto;
        }

        public Event Get(GetEvent request)
        {
            var entity = repository.Get(request.Id);
            var dto = entity.ConvertTo<Event>();

            return dto;
        }

        public CreateEventResponse Post(CreateEventRequest request)
        {
            var entity = request.ConvertTo<Domain.Event>();
            repository.SaveUpdate(entity);

            return entity.ConvertTo<CreateEventResponse>();
        }

        public DeleteEventResponse Delete(DeleteEvent request)
        {
            repository.Delete(request.Id);

            return new DeleteEventResponse() { Id = request.Id };
        }
    }
}

