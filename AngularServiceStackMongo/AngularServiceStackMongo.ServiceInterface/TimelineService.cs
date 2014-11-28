namespace AngularServiceStackMongo.ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ServiceStack;
    using AngularServiceStackMongo.ServiceModel;
    using TweetSharp;
    using AngularServiceStackMongo.Core;

    public class TimelineService : Service
    {
        private readonly AngularServiceStackMongo.Domain.TimelineRepository repository;
        private readonly ITwitterService twitterService;

        public TimelineService(AngularServiceStackMongo.Domain.TimelineRepository repository, ITwitterService twitterService)
        {
            this.repository = repository;
            this.twitterService = twitterService;
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

        [Authenticate]
        public CreateTimelineResponse Post(CreateTimelineRequest request)
        {
            var entity = request.ConvertTo<Domain.Timeline>();

            repository.SaveUpdate(entity);

            SendTweet(request);
   
            return entity.ConvertTo<CreateTimelineResponse>();
        }

         [Authenticate]
        public DeleteTimelineResponse Delete(DeleteTimeline request)
        {
            repository.Delete(request.Id);

            return new DeleteTimelineResponse() { Id = request.Id };
        }

        private void SendTweet(ITimeline request)
        {
            var authToken = this.SessionAs<AuthUserSession>();

            this.twitterService.AuthenticateWith(authToken.GetOAuthTokens("twitter").AccessToken,
                                                 authToken.GetOAuthTokens("twitter").AccessTokenSecret);

            string text = DateTime.Now + request.Name + " updated by " + authToken.TwitterScreenName + " using #Khronos. see " + authToken.ReferrerUrl;

            var status = twitterService.SendTweet(new SendTweetOptions { Status = text });
        }
    }
}

