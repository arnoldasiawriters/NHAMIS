(function () {
    'use script';

    angular
        .module('App', ['appservices'])
        .controller('NominationsCtrl', NominationsCtrlFunction);

    NominationsCtrlFunction.$inject = ['$q', '$window', 'appsvc'];
    function NominationsCtrlFunction($q, $window, appsvc) {
        var ctrl = this;
        var baseUrl = $window.location.origin;

        /**
         * A function for searching previous awards from the role of honor.
         * */
        ctrl.SearchPreviousAwards = function () {
            if (ctrl.SearchNameId.trim().length > 3) {
                var params = { searchKey: ctrl.SearchNameId };
                var promises = [];
                promises.push(appsvc.getItems(baseUrl + '/Nominations/SearchRoleOfHonor', params));

                $q.all(promises)
                    .then(function (results) {
                        ctrl.searchresults = results[0].data;
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            } else {
                ctrl.searchresults = [];
            }
        };
        ctrl.addedCitationRecords = [];
        ctrl.AddCitationRecord = function () {
            var rec = {
                recordtype: ctrl.recordtype,
                organisation: ctrl.organisation,
                startdate: ctrl.startdate,
                enddate: ctrl.enddate,
                narration: ctrl.narration
            };
            ctrl.addedCitationRecords.push(rec);
        };

        ctrl.RemoveCitationRec = function (rec) {
            _.remove(ctrl.addedCitationRecords, function (o) {
                return o.narration == rec.narration; 
            });
        };
    }
})();