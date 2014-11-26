(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('timelineService', ['$resource', function ($resource) {
        
        var timelineResource = $resource('api/timeline/:timelineId');

        return {    
            searchTimelines: function (name) {
                return timelineResource.query({ name: name });
            },
            getTimeline: function (timelineId) {
                return timelineResource.get({ timelineId: timelineId });
            },  
            createTimeline: function () {
                return new timelineResource({
                    name: 'new timeline',
                    text: 'description',
                    startDate: '2014,1,1',
                });
            },
            updateTimeline: function (timeline) {
                return timeline.$save();
            },
            deleteTimeline: function (timelineId) {
            var resourceInstance = new timelineResource();
            return resourceInstance.$delete({ timelineId: timelineId });
            }
        };
    }]);
})();