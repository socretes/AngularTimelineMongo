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

                // check for generic ServiceStack exception
                if (rejection.data && rejection.data.responseStatus && rejection.data.responseStatus.message) {
                    toastr.error(rejection.data.responseStatus.message);
                }
                else {
                    toastr.error("Unexpected error : ".concat(rejection.status, " - ", rejection.statusText));
                }

                usSpinnerService.stop("mainSpinner");

                return $q.reject(rejection);
            }
        };

        return service;
    }
})();