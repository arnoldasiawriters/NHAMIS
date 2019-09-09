(function () {
    'use script';

    angular
        .module('App', [])
        .controller('NominationsCtrl', NominationsCtrlFunction);

    NominationsCtrlFunction.$inject = ['$q'];
    function NominationsCtrlFunction ($q) {
        var ctrl = this;
    }
})();