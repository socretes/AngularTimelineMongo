namespace AngularServiceStackMongo.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using ServiceStack;
    using AngularServiceStackMongo.Core;

    [Route("/tweet", "POST")]
    public class CreateTweetRequest : IReturn<CreateTweetResponse>, ITweet
    {
        public string Id { get; set; }
    }

    public class CreateTweetResponse : ITweet
    {
        public string Id { get; set; }
        public ResponseStatus ResponseStatus { get; set; } //TODO: Determine if this is giving me anything!
    }
}