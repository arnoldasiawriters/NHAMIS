(function () {
    'use script';

    angular
        .module('App', ['appservices'])
        .controller('NominationsCtrl', NominationsCtrlFunction);

    NominationsCtrlFunction.$inject = ['$q', '$window', 'appsvc'];
    function NominationsCtrlFunction($q, $window, appsvc) {
        var ctrl = this;
        var baseUrl = $window.location.origin;
        ctrl.showKenyan = true;

        ctrl.model = {};
        ctrl.model.Nomination = {};
        ctrl.model.CitationAchievement = {};
        ctrl.model.PreviousRecognition = {};
        ctrl.model.Attachment = {};
        ctrl.model.Nomination.Nationality = "Kenyan";

        ctrl.nationalityChanged = function () {
            if (ctrl.model.Nomination.Nationality == "Kenyan") {
                ctrl.showKenyan = true;
            } else {
                ctrl.showKenyan = false;
            }
        };

        var promises = [];
        promises.push(appsvc.getItems(baseUrl + '/Nominations/GetSelectLists'));

        $q.all(promises)
            .then(function (results) {
                ctrl.model.NominatingBodies = results[0].data.NominatingBodies;
                ctrl.model.Nomination.NominationBodyId = ctrl.model.NominatingBodies[0];

                ctrl.model.NominationPeriods = results[0].data.NominationPeriods;
                ctrl.model.Nomination.NominationPeriodId = ctrl.model.NominationPeriods[0];

                ctrl.model.Counties = results[0].data.Counties;
                ctrl.model.Nomination.CountyOfBirthId = ctrl.model.Counties[0];
                //ctrl.model.Nomination.CountyId = ctrl.model.Counties[0];

                ctrl.model.Countries = results[0].data.Countries;
                ctrl.model.Nomination.CountryId = ctrl.model.Countries[0];

                ctrl.model.Salutations = results[0].data.Salutations;
                ctrl.model.Nomination.SalutationId = ctrl.model.Salutations[0];

                ctrl.model.Genders = results[0].data.Genders;
                ctrl.model.Nomination.GenderId = ctrl.model.Genders[0];

                ctrl.model.AcademicQualifications = results[0].data.AcademicQualifications;
                ctrl.model.Nomination.AcademicQualificationId = ctrl.model.AcademicQualifications[0];

                ctrl.model.Medals = results[0].data.Medals;
                ctrl.model.Nomination.MedalId = ctrl.model.Medals[0];

                ctrl.model.AttachmentTypes = results[0].data.AttachmentTypes;
                ctrl.model.Attachment.AttachmentTypeId = ctrl.model.AttachmentTypes[0];

                ctrl.model.Occupations = results[0].data.Occupations;
                ctrl.model.Nomination.OccupationId = ctrl.model.Occupations[0];
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
        ctrl.addedCitationRecords = [];
        ctrl.AddCitationRecord = function () {
            var rec = {
                positionheld: ctrl.model.CitationAchievement.PositionHeld,
                project: ctrl.model.CitationAchievement.Project,
                role: ctrl.model.CitationAchievement.Role,
                achievement: ctrl.model.CitationAchievement.Achivement,
                startdate: ctrl.model.CitationAchievement.StartDate,
                enddate: ctrl.model.CitationAchievement.EndDate
            };
            ctrl.addedCitationRecords.push(rec);
            ctrl.model.CitationAchievement.PositionHeld = "";
            ctrl.model.CitationAchievement.Project = "";
            ctrl.model.CitationAchievement.Role = "";
            ctrl.model.CitationAchievement.Achivement = "";
            ctrl.model.CitationAchievement.StartDate = "";
            ctrl.model.CitationAchievement.EndDate = "";
        };

        ctrl.addedRecognitions = [];
        ctrl.AddRecognition = function () {
            var rec = {
                institution: ctrl.model.PreviousRecognition.RecognizingInstitution,
                achievement: ctrl.model.PreviousRecognition.AchievementTitle,
                award: ctrl.model.PreviousRecognition.Award,
                awarddate: ctrl.model.PreviousRecognition.AwardDate
            };
            ctrl.addedRecognitions.push(rec);
            ctrl.model.PreviousRecognition.RecognizingInstitution = "";
            ctrl.model.PreviousRecognition.AchievementTitle = "";
            ctrl.model.PreviousRecognition.Award = "";
            ctrl.model.PreviousRecognition.AwardDate = "";
        };
        
        ctrl.RemoveCitationRec = function (rec) {
            _.remove(ctrl.addedCitationRecords, function (o) {
                return o.narration == rec.narration && o.awarddate == rec.awarddate;
            });
        };

        ctrl.RemoveRecognitionRec = function (rec) {
            _.remove(ctrl.addedRecognitions, function (o) {
                return o.award == rec.award;
            });
        };

        ctrl.FindSubCounties = function () {
            if (ctrl.model.Nomination.CountyId) {
                var params = { countyid: ctrl.model.Nomination.CountyId.Id };
                appsvc.getItems(baseUrl + "/Nominations/GetSubCounties", params)
                    .then(function (res) {
                        //ctrl.model.Wards = [];
                        ctrl.model.Nomination.WardId = "";

                        ctrl.model.SubCounties = res.data;
                        //ctrl.model.Nomination.SubCountyId = ctrl.model.SubCounties[0];                   
                    })
                    .catch(function (error) {
                        console.log("An error occured while fetching subcounties.", error);
                    });
            }
        };

        ctrl.FindWards = function () {
            if (ctrl.model.Nomination.SubCountyId) {
                var params = { subcountyid: ctrl.model.Nomination.SubCountyId.Id };
                appsvc.getItems(baseUrl + "/Nominations/GetWards", params)
                    .then(function (res) {
                        ctrl.model.Wards = res.data;
                        //ctrl.model.Nomination.WardId = ctrl.model.Wards[0];
                    })
                    .catch(function (error) {
                        console.log("An error occured while fetching wards.", error);
                    });
            }
        };
    }
})();