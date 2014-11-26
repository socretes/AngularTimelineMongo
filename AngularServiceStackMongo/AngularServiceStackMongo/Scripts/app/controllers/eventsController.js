(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('EventsController', ['$scope', 'timelineService', 'eventService', '$routeParams',
            function ($scope, timelineService, eventService, $routeParams) {

                var timeline = timelineService.getTimeline($routeParams.timelineId);
                timeline.$promise.then(function () {
                    $scope.timelineName = angular.copy(timeline).name;
                });

                $scope.timelineId = $routeParams.timelineId;

                $scope.events = eventService.searchEvents($routeParams.timelineId);

                //$scope.delete = function (eventId) {
                //    eventService.deleteEvent(eventId)
                //                                    .then(function () {
                //                                        $scope.events = eventService.searchEvents();
                //                                        toastr.success('Time line Deleted');
                //                                    });
                //};
            }
    ]);
})();