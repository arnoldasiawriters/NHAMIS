(function () {
    'use strict';

    angular
        .module('appservices', [])
        .service('appsvc', UtilServiceFunction);

    UtilServiceFunction.$inject = ['$http'];
    function UtilServiceFunction($http) {
        var svc = this;

        svc.getItems = function (itemsUrl, params) {
            var items = $http({
                method: "GET",
                url: itemsUrl,
                params: params
            });
            return items;
        };

        svc.postItems = function (itemsUrl, body) {
            var items = $http({
                method: "POST",
                url: itemsUrl,
                data: body,
                headers: {
                    "Content-Type": "application/json; charset=utf-8"
                }
            });
            return items;
        };
    }
})();