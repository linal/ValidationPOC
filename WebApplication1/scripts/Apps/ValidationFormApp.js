(function (angular) {
    'use strict';

    var validationFormApp = angular.module("ValidationFormApp", []);

    validationFormApp.controller('FormController', ['$scope', function ($scope) {
        var jsonText = angular.element(document.querySelector('#data')).val();
        if (jsonText != undefined && jsonText !== 'undefined') {
            $scope.data = JSON.parse(jsonText);
        }

        $scope.$watch("data.AnswerMoreQuestions", function (val) {
            if ($scope.data != null && !$scope.data.AnswerMoreQuestions) {
                $scope.data.SeeMoreQuestions = "";
                $scope.data.Velocity = "";
            }
        });
    }]);

})(window.angular);