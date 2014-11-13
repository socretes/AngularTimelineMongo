(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('TimelinesController', ['$scope', 'timelineService',
            function ($scope, timelineService) {
                $scope.timelines = timelineService.searchTimelines();
            }
    ]);
})();