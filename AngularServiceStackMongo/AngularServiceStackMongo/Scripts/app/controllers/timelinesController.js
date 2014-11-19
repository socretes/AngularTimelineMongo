(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('TimelinesController', ['$scope', 'timelineService',
            function ($scope, timelineService) {

                $scope.timelines = timelineService.searchTimelines();

                $scope.delete = function (timeLineId) {
                    timelineService.deleteTimeline(timeLineId)
                                                    .then(function () {
                                                        $scope.timelines = timelineService.searchTimelines();
                                                        toastr.success('Time line Deleted');
                                                    });
                };
            }
    ]);
})();