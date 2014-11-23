﻿(function () {
    "use strict";

    var myAppModule = angular.module('myApp', ['ngRoute', 'ngResource', 'ui.bootstrap', 'angularSpinner']);

    myAppModule.config(['$provide', '$httpProvider', function ($provide, $httpProvider) {
        $provide.decorator('$exceptionHandler', ['$delegate', function ($delegate) {
            return function (exception, cause) {
                $delegate(exception, cause);
                alert(exception.message);
            };
        }]);

        $httpProvider.interceptors.push('httpInterceptor');

    }]);

    myAppModule.config([
        '$routeProvider', function ($routeProvider) {
            $routeProvider.when('/', { templateUrl: 'scripts/app/views/default.html' });
            $routeProvider.when('/:AuthStatus', { templateUrl: 'scripts/app/views/default.html' }); //// successful redirect from auth, s=1, f=AccessTokenFailed, f=RequestTokenFailed
            $routeProvider.when('/timelines', { templateUrl: 'scripts/app/views/timelinesIndex.html', controller: 'TimelinesController' });
            $routeProvider.when('/timelines/new', { templateUrl: 'scripts/app/views/timelinesEditor.html', controller: 'TimelineController' });
            $routeProvider.when('/timelines/:timelineId/edit', { templateUrl: 'scripts/app/views/timelinesEditor.html', controller: 'TimelineController' });
        }
    ]);

    toastr.options.timeOut = 4000;
    toastr.options.positionClass = 'toast-bottom-right';

})();