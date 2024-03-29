﻿(function () {
    'use script';

    angular
        .module('App', ['appservices', 'NominationApprovals', 'directives', 'ui.bootstrap.dialogs', 'directives.dirPagination'])
        .controller('NominationsCtrl', NominationsCtrlFunction);

    NominationsCtrlFunction.$inject = ['$q', '$dialog', '$dialogConfirm', '$dialogAlert', '$window', 'appsvc'];
    function NominationsCtrlFunction($q, $dialog, $dialogConfirm, $dialogAlert, $window, appsvc) {
        var ctrl = this;
        var baseUrl = $window.location.origin;
        ctrl.showKenyan = true;

        ctrl.model = {};
        ctrl.Nationality = "Kenyan";

        ctrl.nationalityChanged = function () {
            if (ctrl.Nationality == "Kenyan") {
                ctrl.showKenyan = true;
            } else {
                ctrl.showKenyan = false;
            }
        };

        ctrl.sort = function (keyname) {
            ctrl.sortKey = keyname; //the sort column name
            ctrl.isASC = !ctrl.isASC; // ASC/DESC sorting
        }

        var curPath = window.location.pathname;
        var idVal = curPath.split('/')[curPath.split('/').length - 1];

        ctrl.Nominations = [];
        ctrl.currentPage = 0;
        ctrl.itemsPerPage = 50;

        var promises = [];
        promises.push(appsvc.getItems(baseUrl + '/Nominations/GetSelectLists'));

        $q.all(promises)
            .then(function (results) {

                ctrl.NominatingBodies = [];
                ctrl.NominatingBodies.push({ Id: 0, Name: "All" });
                _.forEach(results[0].data.NominatingBodies, function (body) {
                    ctrl.NominatingBodies.push(body);
                });

                //ctrl.NominatingBody = ctrl.NominatingBodies[0];

                ctrl.NominationPeriods = results[0].data.NominationPeriods;
                //ctrl.NominationPeriod = ctrl.NominationPeriods[0];

                ctrl.Counties = results[0].data.Counties;
                ctrl.SubCounties = results[0].data.SubCounties;
                ctrl.Wards = results[0].data.Wards;
                //ctrl.CountyOfBirth = ctrl.Counties[0];

                ctrl.Countries = results[0].data.Countries;
                ctrl.Country = ctrl.Countries[0];

                ctrl.Salutations = results[0].data.Salutations;
                //ctrl.Salutation = ctrl.Salutations[0];

                ctrl.Genders = results[0].data.Genders;
                //ctrl.Gender = ctrl.Genders[0];

                ctrl.AcademicQualifications = results[0].data.AcademicQualifications;
                //ctrl.AcademicQualification = ctrl.AcademicQualifications[0];

                ctrl.Medals = results[0].data.Medals;
                //ctrl.Medal = ctrl.Medals[0];

                ctrl.AttachmentTypes = results[0].data.AttachmentTypes;
                //ctrl.AttachmentType = ctrl.AttachmentTypes[0];

                ctrl.Occupations = results[0].data.Occupations;
                //ctrl.Occupation = ctrl.Occupations[0];

                ctrl.PostalCodes = results[0].data.PostalCodes;
                _.forEach(ctrl.PostalCodes, function (p) {
                    p.Code = ("00000" + p.Code).slice(-5)
                });
                ctrl.PostalCode = ctrl.PostalCodes[0];

                if (Number.isInteger(Number(idVal))) {
                    var params = { nominationId: idVal };

                    appsvc
                        .getItems(baseUrl + '/Nominations/GetNomination', params)
                        .then(function (results) {
                            var params = { wardid: results.data.WardId };
                            var param = { idnumber: results.data.IdNumber };
                            var para = { nominationid: idVal };
                            var promises = [];
                            promises.push(appsvc.getItems(baseUrl + '/Nominations/GetCountySubCountyFromWard', params));
                            promises.push(appsvc.getItems(baseUrl + '/Nominations/GetPreviousAwards', param));
                            promises.push(appsvc.getItems(baseUrl + '/Nominations/GetCitations', para));

                            $q
                                .all(promises)
                                .then(function (resinner) {
                                    ctrl.Nomination = results.data;
                                    ctrl.model = ctrl.Nomination;
                                    ctrl.model.DateOfBirth = _.isNil(ctrl.Nomination.DateOfBirth) ? '' : new Date(Number(ctrl.Nomination.DateOfBirth.slice(6, -2)));
                                    ctrl.NominatingBody = _.find(ctrl.NominatingBodies, ['Id', ctrl.Nomination.NominatingBodyId]);
                                    ctrl.NominationPeriod = _.find(ctrl.NominationPeriods, ['Id', ctrl.Nomination.NominationPeriodId]);
                                    ctrl.Salutation = _.find(ctrl.Salutations, ['Id', ctrl.Nomination.SalutationId]);
                                    ctrl.Gender = _.find(ctrl.Genders, ['Id', ctrl.Nomination.GenderId]);
                                    ctrl.Postal = _.find(ctrl.PostalCodes, ['Id', ctrl.Nomination.PostalCodeId]);
                                    ctrl.County = _.find(ctrl.Counties, ['Id', resinner[0].data.County.Id]);
                                    ctrl.SubCounty = _.find(ctrl.SubCounties, ['Id', resinner[0].data.SubCounty.Id]);
                                    ctrl.Ward = _.find(ctrl.Wards, ['Id', ctrl.model.WardId]);
                                    ctrl.AcademicQualification = _.find(ctrl.AcademicQualifications, ['Id', ctrl.Nomination.AcademicQualificationId]);
                                    ctrl.Occupation = _.find(ctrl.Occupations, ['Id', ctrl.Nomination.OccupationId]);
                                    ctrl.Medal = _.find(ctrl.Medals, ['Id', ctrl.Nomination.MedalId]);
                                    ctrl.PreviousNominations = resinner[1].data;
                                    ctrl.CitationAchievements = resinner[2].data.CitationAchievement;
                                    ctrl.PreviousRecognitions = resinner[2].data.PreviousRecognition;
                                    ctrl.NominationAttachments = resinner[2].data.NominationAttachments;

                                    ctrl.model.PreviousNominations = ctrl.PreviousNominations;
                                    ctrl.model.CitationAchievements = ctrl.CitationAchievements;
                                    ctrl.model.PreviousRecognitions = ctrl.PreviousRecognitions;
                                    ctrl.model.NominationAttachments = ctrl.NominationAttachments;

                                    ctrl.CountyOfBirth = _.find(ctrl.Counties, ['CountyName', ctrl.model.CountyOfBirth]);
                                })
                                .catch(function (error) {
                                    console.log(error);
                                });
                        })
                        .catch(function (error) {
                            console.log(error);
                        });
                }
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
            _.remove(ctrl.model.CitationAchievements, function (o) {
                return o.Achivement == rec.Achivement && o.StartDate == rec.StartDate;
            });
        };

        ctrl.RemoveRecognitionRec = function (rec) {
            _.remove(ctrl.model.PreviousRecognitions, function (o) {
                return o.Award == rec.Award;
            });
        };

        ctrl.FindSubCounties = function () {
            if (ctrl.County) {
                var params = { countyid: ctrl.County.Id };
                appsvc.getItems(baseUrl + "/Nominations/GetSubCounties", params)
                    .then(function (res) {
                        ctrl.Ward = "";
                        ctrl.SubCounties = res.data;
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
                    ctrl.model.PostalCodeId = ctrl.PostalCode.Id;
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

        ctrl.UpdateNominationsForm = function () {
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
                    ctrl.model.PostalCodeId = ctrl.PostalCode.Id;

                    ctrl.model.PreviousNominations = ctrl.PreviousNominations;
                    ctrl.model.CitationAchievements = ctrl.CitationAchievements;
                    ctrl.model.PreviousRecognitions = ctrl.PreviousRecognitions;
                    ctrl.model.NominationAttachments = ctrl.NominationAttachments;

                    var body = JSON.stringify(ctrl.model);
                    appsvc
                        .postItems(baseUrl + '/Nominations/UpdateNominationForm', body)
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

        ctrl.GetNominations = function () {
            if (!ctrl.NominationPeriod || !ctrl.NominatingBody) {
                return;
            }

            var params = { periodId: ctrl.NominationPeriod.Id, bodyId: ctrl.NominatingBody.Id };
            var promises = [];
            promises.push(appsvc.getItems(baseUrl + '/Nominations/GetNominations', params));

            $q.all(promises)
                .then(function (results) {
                    if (results[0].data.length > 0) {
                        ctrl.Nominations = [];
                        ctrl.Nominations = results[0].data;
                        ctrl.currentPage = 1;
                        ctrl.itemsPerPage = 50;
                    } else {
                        ctrl.Nominations = [];
                        ctrl.currentPage = 0;
                        ctrl.itemsPerPage = 0;
                        $dialogAlert('There are no records for the period and body.', 'UnSuccessful Transaction');
                    }
                })
                .catch(function (error) {
                    $dialogAlert('An Error occured while querying the database. Contact the system Administrator.', 'UnSuccessful Transaction');
                    console.log(error);
                });
        };

        ctrl.ClearNominations = function () {
            ctrl.Nominations = [];
            ctrl.currentPage = 0;
            ctrl.itemsPerPage = 0;
        };

        ctrl.formatDate = function (date) {
            if (date) {
                var dateOut = new Date(parseInt(date.substr(6)));
                return dateOut;
            }
        };
    }
})();