angular.module("recoveryCIG").config(
    ['$routeProvider', '$locationProvider', 'applicationConfigurationProvider', function ($routeProvider, $locationProvider, applicationConfigurationProvider) {

            var baseSiteUrlPath = $("base").first().attr("href");

            var _bundles = JSON.parse(applicationConfigurationProvider.getBundles());

            this.getApplicationVersion = function () {
                var applicationVersion = applicationConfigurationProvider.getVersion();
                return applicationVersion;
            }

            this.getBundle = function (bundleName) {

                for (var i = 0; i < _bundles.Bundles.length; i++) {
                    if (bundleName.toLowerCase() == _bundles.Bundles[i].BundleName.toLowerCase()) {
                        return _bundles.Bundles[i].Path;
                    }
                }
            }

            this.isLoaded = function (bundleName) {
                for (var i = 0; i < _bundles.Bundles.length; i++) {
                    if (bundleName.toLowerCase() == _bundles.Bundles[i].BundleName.toLowerCase()) {
                        return _bundles.Bundles[i].IsLoaded;
                    }
                }
            }

            this.setIsLoaded = function (bundleName) {
                for (var i = 0; i < _bundles.length; i++) {
                    if (bundleName.toLowerCase() == _bundles.Bundles[i].BundleName.toLowerCase()) {
                        _bundles.Bundles[i].IsLoaded = true;
                        break;
                    }
                }
            }

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
                                var parentPath = path[1];

                                var bundle = this.getBundle(parentPath);
                                var isBundleLoaded = this.isLoaded(parentPath);
                                if (isBundleLoaded == false) {
                                    this.setIsLoaded(parentPath);
                                    var deferred = $q.defer();
                                    require([bundle], function () {
                                        $rootScope.$apply(function () {
                                            deferred.resolve();
                                        });
                                    });
                                    return deferred.promise;
                                }
                            }
                        }]
                    }

                });

            $routeProvider.when('/',
                {

                });

            $routeProvider.otherwise(
                {
                    templateUrl: function (rp) {
                        return baseSiteUrlPath + 'views/shared/Erro404.html';
                    },
                });

            $locationProvider.html5Mode(true);
        }]);