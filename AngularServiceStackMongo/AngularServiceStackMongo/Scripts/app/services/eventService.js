(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('eventService', ['$resource', function ($resource) {
        
        var eventResource = $resource('api/event/:eventId');

        return {
            searchEvents: function (timelineId, name) {
                return eventResource.query({ timelineId: timelineId }, { name: name });
            },
            getEvent: function (eventId) {
                return eventResource.get({ eventId: eventId });
            },
            createEvent: function (timelineId) {
                return new eventResource({
                    timelineId: timelineId,
                    headline: 'new Event',
                    text: '<p>description</p>',
                    startDate: moment().format("YYYY-MM-DD"),
                    endDate: moment().format("YYYY-MM-DD"),
                    media: 'http://',
                });
            },
            updateEvent: function (event) {
                return event.$save();
            }
        };
    }]);
})();