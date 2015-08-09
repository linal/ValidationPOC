/// <reference path="../../ValidationPoc/Scripts/angular.js"/>
/// <reference path="../../ValidationPoc/Scripts/App/QuestionnaireApp.js"/>
describe('QuestionnaireController', function () {
    /*
    beforeEach(module('QuestionnaireApp'));

    var $controller;

    beforeEach(inject(function (_$controller_) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $controller = _$controller_;
    }));
    */
    describe('$scope.addPreviousName', function () {
        it('adds a previous name to the previous name collection', function () {
            var $scope = {};

            var controller = module('QuestionnaireApp').controller('QuestionnaireController', { $scope: $scope });
            $scope.addPreviousName();
            expect($scope.data.previousNames.length).toEqual(1);
        });
    });
});