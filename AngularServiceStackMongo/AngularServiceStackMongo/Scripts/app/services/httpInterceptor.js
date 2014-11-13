(function () {
    'use strict';

    var serviceId = 'httpInterceptor';

    angular.module('myApp').factory(serviceId, ['$q', 'usSpinnerService', httpInterceptor]);

    function httpInterceptor($q, usSpinnerService) {
        var service = {
            'request': function (config) {
                usSpinnerService.spin("mainSpinner");
                return config || $q.when(config);
            },
            'requestError': function (rejection) {
                usSpinnerService.stop("mainSpinner");
                return $q.reject(rejection);
            },
            'response': function (response) {
                usSpinnerService.stop("mainSpinner");
                return response || $q.when(response);
            },
            'responseError': function (rejection) {
                var hasErrorMessage = false;
                var errorMessage;
                // check for generic ServiceStack exception
                if (rejection.data && rejection.data.responseStatus && rejection.data.responseStatus.message) {
                    alert("Error: " + rejection.data.responseStatus.message);
                }
                else {
                    alert("Unexpected error. TODO: Should probably handle this better. Maybe look at status code");
                }

                usSpinnerService.stop("mainSpinner");

                return $q.reject(rejection);
            }
        };

        return service;
    }
})();