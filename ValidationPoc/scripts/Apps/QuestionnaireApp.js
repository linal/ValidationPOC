var QuestionnaireApp;
(function (QuestionnaireApp) {
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
            this.scope = $scope;
            var jsonText = angular.element(document.querySelector('#data')).val();
            if (jsonText != undefined && jsonText !== 'undefined') {
                this.scope.data = JSON.parse(jsonText);
            }
            if (this.scope.data == null) {
                this.scope.data = new QuestionnaireModel();
            }
            this.scope.$watch("data.answerMoreQuestions", function () {
                if ($scope.data != null && !$scope.data.answerMoreQuestions) {
                    $scope.data.seeMoreQuestions = false;
                    $scope.data.velocity = null;
                }
            });
            this.scope.addPreviousName = function () {
                _this.scope.data.previousNames.push(new PreviousName());
            };
            this.scope.removePreviousName = function (index) {
                _this.scope.data.previousNames.splice(index, 1);
            };
        }
        return QuestionnaireController;
    })();
    QuestionnaireApp.QuestionnaireController = QuestionnaireController;
    angular.module('QuestionnaireApp', ['ngAnimate'])
        .controller("QuestionnaireController", QuestionnaireController);
})(QuestionnaireApp || (QuestionnaireApp = {}));
//# sourceMappingURL=QuestionnaireApp.js.map