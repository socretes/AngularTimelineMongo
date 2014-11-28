(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('TimelineController', ['$scope', '$location', '$routeParams', 'timelineService',
        function ($scope, $location, $routeParams, timelineService) {
            $scope.isNew = !$routeParams.timelineId;

            var originalTimeline = null;

            if ($scope.isNew) {
                $scope.formTitle = "Add new timeline";
                $scope.timeline = timelineService.createTimeline();
            } else {
                $scope.formTitle = "Update timeline";
                originalTimeline = timelineService.getTimeline($routeParams.timelineId);
                originalTimeline.$promise.then(function () {
                    $scope.timeline = angular.copy(originalTimeline);
                });
            }

            $scope.submit = function () {
                
                timelineService.updateTimeline($scope.timeline)
                                                .then(function () {
                                                    toastr.success('Time line Updated');
                                                    $location.path('/timelines');
                                                });

            };

            $scope.cancel = function () {
                $location.path('/timelines');
            };
        }
    ]);
})();