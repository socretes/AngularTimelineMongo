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

                $scope.delete = function (id) {
                    console.log('the event id is' + id);
                    eventService.deleteEvent(id)
                                                    .then(function () {
                                                        $scope.events = eventService.searchEvents($routeParams.timelineId);
                                                        toastr.success('Event Deleted');
                                                    });
                };
            }
    ]);
})();