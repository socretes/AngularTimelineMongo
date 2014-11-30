(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('tweetService', ['$resource', function ($resource) {

        var tweetResource = $resource('api/tweet/:timelineId');

        return {
            createTweet: function (timelineId) {
                var tweet = new tweetResource({
                    Id: timelineId,
                });
                return tweet.$save();
            }
        };
    }]);
})();