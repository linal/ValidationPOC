var QuestionnaireApp;
(function (QuestionnaireApp) {
    "use strict";
    var BasicColor;
    (function (BasicColor) {
        BasicColor[BasicColor["Red"] = 0] = "Red";
        BasicColor[BasicColor["Blue"] = 1] = "Blue";
        BasicColor[BasicColor["Green"] = 2] = "Green";
        BasicColor[BasicColor["Yellow"] = 3] = "Yellow";
    })(BasicColor || (BasicColor = {}));
    var OtherGreens;
    (function (OtherGreens) {
        OtherGreens[OtherGreens["LightGreen"] = 0] = "LightGreen";
        OtherGreens[OtherGreens["DarkGreen"] = 1] = "DarkGreen";
    })(OtherGreens || (OtherGreens = {}));
    var QuestionnaireModel = (function () {
        function QuestionnaireModel() {
        }
        return QuestionnaireModel;
    })();
    QuestionnaireApp.QuestionnaireModel = QuestionnaireModel;
    var PreviousName = (function () {
        function PreviousName() {
        }
        return PreviousName;
    })();
    QuestionnaireApp.PreviousName = PreviousName;
    var QuestionnaireController = (function () {
        function QuestionnaireController($scope) {
            var _this = this;
            this.$scope = $scope;
            this.scope = $scope;
            this.scope.data = this.getQuestionnaireModel();
            this.scope.$watch(function () { return $scope.data.answerMoreQuestions; }, function () {
                _this.resetSeeMoreQuestions();
            });
            this.scope.addPreviousName = function () {
                _this.scope.data.previousNames.push(new PreviousName());
            };
            this.scope.removePreviousName = function (index) {
                _this.scope.data.previousNames.splice(index, 1);
            };
        }
        QuestionnaireController.prototype.getQuestionnaireModel = function () {
            var jsonText = angular.element(document.querySelector('#data')).val();
            var model = null;
            if (jsonText != undefined && jsonText !== 'undefined') {
                model = JSON.parse(jsonText);
            }
            if (model == null) {
                return new QuestionnaireModel();
            }
            return model;
        };
        QuestionnaireController.prototype.resetSeeMoreQuestions = function () {
            if (this.scope.data != null && !this.scope.data.answerMoreQuestions) {
                this.scope.data.seeMoreQuestions = false;
                this.scope.data.velocity = null;
            }
        };
        return QuestionnaireController;
    })();
    QuestionnaireApp.QuestionnaireController = QuestionnaireController;
    angular.module('QuestionnaireApp', ['ngAnimate'])
        .controller("QuestionnaireController", QuestionnaireController);
})(QuestionnaireApp || (QuestionnaireApp = {}));
