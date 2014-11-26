(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('TimelineViewerController', ['$scope', '$location', '$routeParams', 'timelineService', 'eventService',
        function ($scope, $location, $routeParams, timelineService, eventService) {
            var timelinePromise = timelineService.getTimeline($routeParams.timelineId);

            timelinePromise.$promise.then(function () {
                var timeline = angular.copy(timelinePromise);
                var eventsPromise = eventService.searchEvents($routeParams.timelineId);

                eventsPromise.$promise.then(function () {

                    var events = angular.copy(eventsPromise);

                    var controlEvents = new Array();
                    
                    for (var i = 0; i < events.length; i++)
                    {
                        var item = {
                            "startDate": moment(events[i].startDate).format("YYYY,MM,DD"),
                            "endDate": moment(events[i].endDate).format("YYYY,MM,DD"),
                            "headline": events[i].headline,
                            "text": events[i].text,
                            "asset":
                            {
                                "media": events[i].media,
                                "credit": "",
                                "caption": ""
                            }
                        };

                        controlEvents.push(item);
                    }

                    var controlTimeline = {
                        "timeline":
                        {
                            "headline": timeline.name,
                            "type": "default",
                            "text": timeline.text,
                            "startDate": moment(timeline.startDate).format("YYYY,MM,DD"),
                            "date": controlEvents
                        }
                    };

                    createStoryJS({
                        type: 'timeline',
                        width: '100%',
                        height: '600',
                        source: controlTimeline,
                        embed_id: 'jsTimeline'
                    });

                });
            });
        }
    ]);
})();