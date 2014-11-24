namespace AngularServiceStackMongo.Core
{
    using System;

    public interface IEvent
    {
        string TimelineId { get; set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        string Headline { get; set; }

        string Text { get; set; }

        string Media { get; set; }

        string MediaCredit { get; set; }

        string MediaCaption { get; set; }

        string MediaThumbnail { get; set; }

        string Type { get; set; }

        string Tag { get; set; }
    }
}
