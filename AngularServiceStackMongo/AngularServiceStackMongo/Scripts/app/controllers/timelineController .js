(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('TimelineController', ['$scope', '$location', '$routeParams', 'timelineService',
        function ($scope, $location, $routeParams, timelineService) {

            //// set the timeline object based on current ulr/page, we will call save on this later on submit
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

            ////use action set above
            $scope.submit = function () {
                ////updatetimeline invokes $save on the defined timeline action
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