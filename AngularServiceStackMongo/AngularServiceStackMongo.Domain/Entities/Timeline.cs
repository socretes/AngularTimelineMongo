namespace AngularServiceStackMongo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AngularServiceStackMongo.Core;

    public class Timeline : MongoEntity, ITimeline
    {
        public Timeline(string name, string userName)
            : base(userName)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
