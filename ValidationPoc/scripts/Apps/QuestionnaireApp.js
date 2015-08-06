(function (angular) {
    'use strict';

    var questionnaireApp = angular.module("QuestionnaireApp", ['ngAnimate']);

    questionnaireApp.controller('QuestionnaireController', ['$scope', function ($scope) {

        $scope.animate = true;

        var jsonText = angular.element(document.querySelector('#data')).val();
        if (jsonText != undefined && jsonText !== 'undefined') {
            $scope.data = JSON.parse(jsonText);
        }
        if ($scope.data == null) {
            $scope.data = {
                PreviousNames: []
            };
        }

        $scope.$watch("data.AnswerMoreQuestions", function (val) {
            if ($scope.data != null && !$scope.data.AnswerMoreQuestions) {
                $scope.data.SeeMoreQuestions = "";
                $scope.data.Velocity = "";
            }
        });

        $scope.AddPreviousName = function () {
            $scope.data.PreviousNames.push({});
        }

        $scope.removePreviousName = function (index) {
            //var index = $scope.PreviousNames.indexOf(item);
            $scope.data.PreviousNames.splice(index, 1);
        }
    }]);

})(window.angular);