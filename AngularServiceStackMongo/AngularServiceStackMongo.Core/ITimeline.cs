namespace AngularServiceStackMongo.Core
{
    public interface ITimeline
    {
        string Name { get; set; }

        string Type { get; set; }

        string Text { get; set; }

        string Media { get; set; }

        string Credit { get; set; }

        string Caption { get; set; }
    }
}
