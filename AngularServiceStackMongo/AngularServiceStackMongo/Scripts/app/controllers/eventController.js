(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('EventController', ['$scope', '$location', '$routeParams', 'eventService',
        function ($scope, $location, $routeParams, eventService) {
            $scope.isNew = !$routeParams.eventId;

            var originalEvent = null;

            if ($scope.isNew) {
                $scope.formTitle = "Add new event";
                $scope.event = eventService.createEvent($routeParams.timelineId);
            } else {
                $scope.formTitle = "Update event";
                originalEvent = eventService.getEvent($routeParams.eventId);
                originalEvent.$promise.then(function () {
                    originalEvent.startDate = moment(originalEvent.startDate).format("YYYY-MM-DD");
                    originalEvent.endDate = moment(originalEvent.endDate).format("YYYY-MM-DD");
                    $scope.event = angular.copy(originalEvent);
                });
            }

            $scope.submit = function () {
                eventService.updateEvent($scope.event)
                                                .then(function () {
                                                    toastr.success('Event Updated');
                                                    $location.path('/events/' + $routeParams.timelineId);
                                                });
            };

            $scope.cancel = function () {
                $location.path('/events/' + $routeParams.timelineId);
            };
        }
    ]);
})();