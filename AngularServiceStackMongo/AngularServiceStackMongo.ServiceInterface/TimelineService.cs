namespace AngularServiceStackMongo.ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ServiceStack;
    using AngularServiceStackMongo.ServiceModel;

    ////[Authenticate]  TODO disabled for convenience while we build
    public class TimelineService : Service
    {
        private readonly AngularServiceStackMongo.Domain.TimelineRepository repository;

        public TimelineService(AngularServiceStackMongo.Domain.TimelineRepository repository)
        {
            this.repository = repository;
        }

        public List<Timeline> Get(FindTimelines request)
        {
            var timelines = repository.GetAll().ToList();
            var dto = timelines.ConvertAll(x => x.ConvertTo<Timeline>());
            return dto;
        }
        
        public Timeline Get(GetTimeline request)
        {
            var timeline = repository.Get(request.Id);
            var dto = timeline.ConvertTo<Timeline>();

            return dto;
        }

        public CreateTimelineResponse Post(CreateTimelineRequest request)
        {
            var entity = request.ConvertTo<Domain.Timeline>();
            repository.SaveUpdate(entity);

            return entity.ConvertTo<CreateTimelineResponse>();
        }

        public DeleteTimelineResponse Delete(DeleteTimeline request)
        {
            repository.Delete(request.Id);

            return new DeleteTimelineResponse() { Id = request.Id };
        }
    }
}

