(function () {
    'use script';

    angular
        .module('App', ['appservices', 'NominationApprovals', 'directives', 'ui.bootstrap.dialogs'])
        .controller('NominationsCtrl', NominationsCtrlFunction);

    NominationsCtrlFunction.$inject = ['$q', '$dialog', '$dialogConfirm', '$dialogAlert', '$window', 'appsvc'];
    function NominationsCtrlFunction($q, $dialog, $dialogConfirm, $dialogAlert, $window, appsvc) {
        var ctrl = this;
        var baseUrl = $window.location.origin;
        ctrl.showKenyan = true;

        ctrl.model = {};
        ctrl.model.PostalAddress = "";
        ctrl.Nationality = "Kenyan";

        ctrl.nationalityChanged = function () {
            if (ctrl.Nationality == "Kenyan") {
                ctrl.showKenyan = true;
            } else {
                ctrl.showKenyan = false;
            }
        };

        var promises = [];
        promises.push(appsvc.getItems(baseUrl + '/Nominations/GetSelectLists'));

        $q.all(promises)
            .then(function (results) {
                ctrl.NominatingBodies = results[0].data.NominatingBodies;
                ctrl.NominatingBody = ctrl.NominatingBodies[0];

                ctrl.NominationPeriods = results[0].data.NominationPeriods;
                ctrl.NominationPeriod = ctrl.NominationPeriods[0];

                ctrl.Counties = results[0].data.Counties;
                ctrl.CountyOfBirth = ctrl.Counties[0];
                //ctrl.model.Nomination.CountyId = ctrl.model.Counties[0];

                ctrl.Countries = results[0].data.Countries;
                ctrl.Country = ctrl.Countries[0];

                ctrl.Salutations = results[0].data.Salutations;
                ctrl.Salutation = ctrl.Salutations[0];

                ctrl.Genders = results[0].data.Genders;
                ctrl.Gender = ctrl.Genders[0];

                ctrl.AcademicQualifications = results[0].data.AcademicQualifications;
                ctrl.AcademicQualification = ctrl.AcademicQualifications[0];

                ctrl.Medals = results[0].data.Medals;
                ctrl.Medal = ctrl.Medals[0];

                ctrl.AttachmentTypes = results[0].data.AttachmentTypes;
                ctrl.AttachmentType = ctrl.AttachmentTypes[0];

                ctrl.Occupations = results[0].data.Occupations;
                ctrl.Occupation = ctrl.Occupations[0];

                ctrl.PostalCodes = results[0].data.PostalCodes;
                ctrl.Town = ctrl.PostalCodes[0];
                ctrl.PostalCode = ("00000" + ctrl.PostalCodes[0].Code).slice(-5);
            })
            .catch(function (error) {
                console.log("An error occured.", error);
            });

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
                        _.forEach(ctrl.searchresults, function (o) {
                            o.selected = false;
                        });
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            } else {
                ctrl.searchresults = _.filter(ctrl.searchresults, ["selected", true]);
            }
        };
        ctrl.model.CitationAchievements = [];
        ctrl.AddCitationRecord = function () {
            var rec = {
                PositionHeld: ctrl.PositionHeld,
                Project: ctrl.Project,
                Role: ctrl.Role,
                Achivement: ctrl.Achivement,
                StartDate: ctrl.StartDate,
                EndDate: ctrl.EndDate
            };
            ctrl.model.CitationAchievements.push(rec);
            ctrl.PositionHeld = "";
            ctrl.Project = "";
            ctrl.Role = "";
            ctrl.Achivement = "";
            ctrl.StartDate = "";
            ctrl.EndDate = "";
        };

        ctrl.model.PreviousRecognitions = [];
        ctrl.AddRecognition = function () {
            var rec = {
                RecognizingInstitution: ctrl.RecognizingInstitution,
                AchievementTitle: ctrl.AchievementTitle,
                Award: ctrl.Award,
                AwardDate: ctrl.AwardDate
            };
            ctrl.model.PreviousRecognitions.push(rec);
            ctrl.RecognizingInstitution = "";
            ctrl.AchievementTitle = "";
            ctrl.Award = "";
            ctrl.AwardDate = "";
        };

        ctrl.RemoveCitationRec = function (rec) {
            _.remove(ctrl.CitationAchievements, function (o) {
                return o.Achivement == rec.Achivement && o.StartDate == rec.StartDate;
            });
        };

        ctrl.RemoveRecognitionRec = function (rec) {
            _.remove(ctrl.PreviousRecognitions, function (o) {
                return o.Award == rec.Award;
            });
        };

        ctrl.GetPostalCode = function () {
            if (ctrl.Town) {
                ctrl.PostalCode = ("00000" + ctrl.Town.Code).slice(-5);
            }
        };

        ctrl.FindSubCounties = function () {
            if (ctrl.County) {
                var params = { countyid: ctrl.County.Id };
                appsvc.getItems(baseUrl + "/Nominations/GetSubCounties", params)
                    .then(function (res) {
                        //ctrl.model.Wards = [];
                        ctrl.Ward = "";

                        ctrl.SubCounties = res.data;
                        //ctrl.model.Nomination.SubCountyId = ctrl.model.SubCounties[0];                   
                    })
                    .catch(function (error) {
                        console.log("An error occured while fetching subcounties.", error);
                    });
            }
        };

        ctrl.FindWards = function () {
            if (ctrl.SubCounty) {
                var params = { subcountyid: ctrl.SubCounty.Id };
                appsvc.getItems(baseUrl + "/Nominations/GetWards", params)
                    .then(function (res) {
                        ctrl.Wards = res.data;
                        //ctrl.model.Nomination.WardId = ctrl.model.Wards[0];
                    })
                    .catch(function (error) {
                        console.log("An error occured while fetching wards.", error);
                    });
            }
        };

        ctrl.SubmitNominationsForm = function () {

            $dialogConfirm("Submit Approvals?", "Confirm Transaction")
                .then(function () {
                    ctrl.model.NominatingBodyId = ctrl.NominatingBody.Id;
                    ctrl.model.NominationPeriodId = ctrl.NominationPeriod.Id;
                    ctrl.model.CountryId = ctrl.Country.Id;
                    ctrl.model.SalutationId = ctrl.Salutation.Id;
                    ctrl.model.GenderId = ctrl.Gender.Id;
                    ctrl.model.AcademicQualificationId = ctrl.AcademicQualification.Id;
                    ctrl.model.OccupationId = ctrl.Occupation.Id;
                    ctrl.model.MedalId = ctrl.Medal.Id;
                    ctrl.model.WardId = ctrl.Ward.Id;
                    ctrl.model.CountyOfBirth = ctrl.CountyOfBirth.CountyName;
                    ctrl.model.Nationality = ctrl.Nationality;
                    ctrl.model.PostalCodeId = ctrl.Town.Id;
                    var body = JSON.stringify(ctrl.model);
                    appsvc
                        .postItems(baseUrl + '/Nominations/PostNominationForm', body)
                        .then(function (results) {
                            $window.location = baseUrl + '/Nominations';
                            $dialogAlert('Nomination Form has been Submitted Successfully.', 'Successful Transaction');                            
                        })
                        .catch(function (error) {
                            $dialogAlert('An Error occured while Submitting the Nomination Form. Contact the system Administrator.', 'UnSuccessful Transaction');
                            console.log("Error: ", error);
                        });
                });
        };

        ctrl.model.NominationAttachments = [];
        ctrl.AddAttachment = function () {
            var attachadd = true;
            _.forEach(ctrl.model.NominationAttachments, function (o) {
                if (o.AttachmentType.Name == ctrl.AttachmentType.Name) {
                    $dialogAlert('Attachment Type Already Added.', 'UnSuccessfull Transaction');
                    attachadd = false;
                    return;
                }
            });

            if (attachadd) {
                var rec = {
                    AttachmentType: ctrl.AttachmentType,
                    AttachmentUrl: ctrl.attachment[0].name,
                    Attachment: ctrl.attachment[0]
                };
                ctrl.model.NominationAttachments.push(rec);
                ctrl.AttachmentUrl = "";
                ctrl.attachment = null;
            }

        };

        ctrl.CheckIfNumber = function () {
            if (!Number.isInteger(ctrl.model.PostalAddress)) {
                ctrl.model.PostalAddress = "";
            }
        };
    }
})();