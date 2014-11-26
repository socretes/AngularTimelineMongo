(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.directive("jsTimeline", function () {
        return {
            replace: true,
            template: "<div id='jsTimeline'></div>",
            scope: { source: "=timelineSource" },
            link: function (scope, element, attrs) {
                createStoryJS({
                    type: 'timeline',
                    width: '800',
                    height: '600',
                    source: scope.source,
                    embed_id: 'jsTimeline'
                });
            }
        }
    });
})();