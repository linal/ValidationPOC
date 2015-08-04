(function (angular) {
    'use strict';

    var questionnaireApp = angular.module("QuestionnaireApp", []);

    questionnaireApp.controller('QuestionnaireController', ['$scope', function ($scope) {
        var jsonText = angular.element(document.querySelector('#data')).val();
        if (jsonText != undefined && jsonText !== 'undefined') {
            $scope.data = JSON.parse(jsonText);
        } else {
            $scope.data = {};
        }

        $scope.$watch("data.AnswerMoreQuestions", function (val) {
            if ($scope.data != null && !$scope.data.AnswerMoreQuestions) {
                $scope.data.SeeMoreQuestions = "";
                $scope.data.Velocity = "";
            }
        });
    }]);

})(window.angular);