angular.module("resourceSkillsAnalysis").config(
    ['$routeProvider', '$locationProvider', 'applicationConfigurationProvider',
        function ($routeProvider, $locationProvider, applicationConfigurationProvider) {
            this.getApplicationVersion = function () {
                var applicationVersion = applicationConfigurationProvider.getVersion();
                return applicationVersion;
            }

            var baseSiteUrlPath = $("base").first().attr("href");

            $routeProvider.when('/:section',
                {
                    templateUrl: function (rp) {
                        if (rp.aspxerrorpath != undefined)
                            return baseSiteUrlPath + 'views/shared/Erro404.html';
                        else
                            return baseSiteUrlPath + 'views/' + rp.section + '/' + 'Index.html?v=' + this.getApplicationVersion();
                    },

                    resolve: {
                        load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {
                            if ($location.$$url.indexOf('aspxerrorpath') == -1) {
                                var path = $location.path().split("/");
                                var directory = path[1];
                                var controllerToLoad = '';


                                controllerToLoad = "Scripts/" + directory + "/" + directory.charAt(0).toLowerCase() + directory.slice(1) + "Controller.js?v=" + this.getApplicationVersion();

                                var deferred = $q.defer();

                                require([controllerToLoad], function () {
                                    $rootScope.$apply(function () {
                                        deferred.resolve();
                                    });
                                });

                                return deferred.promise;
                            }
                        }]
                    }
                });

            $routeProvider.when('/',
                {
                    templateUrl: 'views/Home/Index.html',
                });

            $routeProvider.otherwise(
                {
                    templateUrl: function (rp) {
                        return baseSiteUrlPath + 'views/shared/Erro404.html';
                    },
                });

            $locationProvider.html5Mode(true);
        }]);