namespace AngularServiceStackMongo.ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ServiceStack;
    using AngularServiceStackMongo.ServiceModel;
    using TweetSharp;
    using AngularServiceStackMongo.Core;

    public class TweetService : Service
    {
        private readonly ITwitterService twitterService;

        public TweetService(AngularServiceStackMongo.Domain.TimelineRepository repository, ITwitterService twitterService)
        {
            this.twitterService = twitterService;
        }

        [Authenticate]
        public CreateTweetResponse Post(CreateTweetRequest request)
        {
            SendTweet(request.Id);

            return new CreateTweetResponse();
        }

        private void SendTweet(string id)
        {
            var authToken = this.SessionAs<AuthUserSession>();

            this.twitterService.AuthenticateWith(authToken.GetOAuthTokens("twitter").AccessToken,
                                                 authToken.GetOAuthTokens("twitter").AccessTokenSecret);
            string text = DateTime.Now + " TimeLine updated by " + authToken.TwitterScreenName + " using #Khronos. "
                + "http://jonhackathon.azurewebsites.net/#/timelines/" + id + "/viewer";

            var status = twitterService.SendTweet(new SendTweetOptions { Status = text });
        }
    }
}

