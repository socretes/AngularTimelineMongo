namespace AngularServiceStackMongo.ServiceModel
{
    using System;
    using AngularServiceStackMongo.Core;

    public class Timeline : ITimeline, IIdentifiable<string>, IUser
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public string Media { get; set; }

        public string Credit { get; set; }

        public string Caption { get; set; }

        public DateTime StartDate { get; set; }
    }
}
