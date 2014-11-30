(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('TimelinesController', ['$scope', 'timelineService','tweetService',
            function ($scope, timelineService, tweetService) {

                $scope.timelines = timelineService.searchTimelines();

                $scope.delete = function (timeLineId) {
                    timelineService.deleteTimeline(timeLineId)
                                                    .then(function () {
                                                        $scope.timelines = timelineService.searchTimelines();
                                                        toastr.success('Time line Deleted');
                                                    });
                };


                $scope.tweet = function (timeLineId) {
                    tweetService.createTweet(timeLineId)
                                                    .then(function () {
                                                        toastr.success('Tweet!');
                                                    });
                };
            }
    ]);
})();