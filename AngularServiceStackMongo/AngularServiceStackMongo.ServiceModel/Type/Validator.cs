namespace AngularServiceStackMongo.ServiceModel.Type
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AngularServiceStackMongo.Core;
    using AngularServiceStackMongo.Domain;
    using ServiceStack;
    using ServiceStack.FluentValidation;
    using ServiceStack.FluentValidation.Results;

    public class TimelineValidator : AbstractValidator<ServiceModel.CreateTimelineRequest>
    {
        public TimelineValidator(TimelineRepository repository)
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).NotNull();
            RuleFor(x => x.Name.Length).LessThan(50);

            RuleFor(b => b.Text).NotEmpty();
            RuleFor(b => b.Text).NotNull();
            RuleFor(x => x.Text.Length).LessThan(50);

            RuleSet(ApplyTo.Post, () =>
            {
                Custom(b =>
                {
                    if (repository.GetByName(b.Name).Count() >= 10) //TODO: Remove once server side paging is implemented
                    {
                        return new ValidationFailure("", "You can only upload a set number of timelines", "Max number of uploads");
                    }
                    return null;
                });
            });
        }
    }

    public class EventValidator : AbstractValidator<ServiceModel.CreateEventRequest>
    {
        public EventValidator(EventRepository eventRepository, TimelineRepository timelineRepository)
        {
            RuleFor(b => b.TimelineId).NotEmpty();
            RuleFor(b => b.TimelineId).NotNull();

            RuleFor(b => b.Headline).NotEmpty();
            RuleFor(b => b.Headline).NotNull();
            RuleFor(x => x.Headline.Length).LessThan(50);

            RuleFor(b => b.Text).NotEmpty();
            RuleFor(b => b.Text).NotNull();
            RuleFor(x => x.Text.Length).LessThan(50);

            RuleSet(ApplyTo.Post, () =>
            {
                Custom(b =>
                {
                    if (b.StartDate > b.EndDate)
                    {
                        return new ValidationFailure("Dates", "Timeline start date after end date", "Dates", b.StartDate);
                    }
                    return null;
                });

                Custom(b =>
                {
                    if (timelineRepository.Get(b.TimelineId) == null)
                    {
                        return new ValidationFailure("TimelineId", "Timeline does not exist", "DoesNotExist", b.TimelineId);
                    }
                    return null;
                });
            });
        }
    }
}
