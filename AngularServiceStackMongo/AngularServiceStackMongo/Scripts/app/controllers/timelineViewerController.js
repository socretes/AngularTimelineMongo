(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('TimelineViewerController', ['$scope', '$location', '$routeParams', 'timelineService',
        function ($scope, $location, $routeParams, timelineService) {

            $scope.timeline = {
                "timeline":
                {
                    "headline": "DC Growth",
                    "type": "default",
                    "text": "2014 Goals",
                    "startDate": "2014,1,1",
                    "date": [
                    {
                        "startDate": "2014,1,2",
                        "endDate": "2012,1,27",
                        "headline": "January Release",
                        "text": "<p>Brand and Payroll updates</p>",
                        "asset":
                        {
                            "media": "",
                            "credit": "",
                            "caption": ""
                        }
                    },
                    {
                        "startDate": "2014,2,1",
                        "endDate": "2012,2,27",
                        "headline": "Februray Release",
                        "text": "<p>Bulk UPdates</p>",
                        "asset":
                        {
                            "media": "",
                            "credit": "",
                            "caption": ""
                        }
                    }]
                }
            };
        }
    ]);
})();