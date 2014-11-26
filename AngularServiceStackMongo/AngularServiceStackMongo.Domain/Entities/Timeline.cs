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

        public string Type { get; set; }

        public string Text { get; set; }

        public string Media { get; set; }

        public string Credit { get; set; }

        public string Caption { get; set; }

        public DateTime StartDate { get; set; }
    }
}
