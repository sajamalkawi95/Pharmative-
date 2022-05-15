(function () {
    'use strict';

    angular
        .module('app')
        .controller('table', table);

    table.$inject = ['$location'];

    function table($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'table';

        activate();

        function activate() { }
    }
})();
