(function () {
    'use strict';

    angular
        .module('NominationApprovals', ['appservices', 'directives', 'ui.bootstrap.dialogs'])
        .controller('NominationApprovalsCtrl', NominationApprovalsCtrlFunction);

    NominationApprovalsCtrlFunction.$inject = ['$q', '$dialog', '$dialogConfirm', '$dialogAlert', '$window', 'appsvc'];
    function NominationApprovalsCtrlFunction($q, $dialog, $dialogConfirm, $dialogAlert, $window, appsvc) {
        var ctrl = this;
        var baseUrl = $window.location.origin;
        var promises = [];

        ctrl.NominationApprovals = [];

        promises.push(appsvc.getItems(baseUrl + '/Nominations/GetApprovalsSelectLists'));
        $q.all(promises)
            .then(function (results) {
                ctrl.NominationPeriods = results[0].data.NominationPeriods;
                ctrl.NominationPeriod = ctrl.NominationPeriods[0];

                ctrl.ApprovalStages = results[0].data.ApprovalStages;
                ctrl.ApprovalStage = ctrl.ApprovalStages[0];

                ctrl.Medals = results[0].data.Medals;
                ctrl.Medal = ctrl.Medals[0];
            })
            .catch(function (error) {
                console.log(error);
                $dialogAlert('An error occured while loading the form.', 'UnSuccessful Transaction');
            });

        ctrl.SearchApprovals = function () {
            var params = { periodId: ctrl.NominationPeriod.Id, stageId: ctrl.ApprovalStage.Id };
            var promises = [];
            promises.push(appsvc.getItems(baseUrl + '/Nominations/SearchNominationApprovals', params));

            $q.all(promises)
                .then(function (results) {
                    if (results[0].data.length > 0) {
                        ctrl.NominationApprovals = results[0].data;
                    } else {
                        ctrl.NominationApprovals = [];
                        $dialogAlert('There are no records for the period and stage.', 'UnSuccessful Transaction');
                    }
                })
                .catch(function (error) {
                    console.log(error);
                });
        };

        ctrl.SubmitApprovals = function () {
            $dialogConfirm("Submit Approvals?", "Confirm Transaction")
                .then(function () {
                    ctrl.model = [];
                    _.forEach(ctrl.NominationApprovals, function (o) {
                        if (o.Status) {
                            var approval = {};
                            approval.Id = o.Id;
                            approval.MedalId = o.Medal.Id;
                            approval.Status = o.Status;
                            ctrl.model.push(approval);
                        }
                    });

                    var body = JSON.stringify(ctrl.model);
                    appsvc
                        .postItems(baseUrl + '/Nominations/PostNominationApprovals', body)
                        .then(function (results) {
                            $dialogAlert('Approvals have been Submitted Successfully.', 'Successful Transaction');
                            ctrl.NominationApprovals = [];
                        })
                        .catch(function (error) {
                            console.log("Error: ", error);
                        });
                });
        };

        ctrl.NominationPeriodsChanged = function () {
            ctrl.NominationApprovals = [];
        };

        ctrl.ApprovalStagesChanged = function () {
            ctrl.NominationApprovals = [];
        };
    }
})();