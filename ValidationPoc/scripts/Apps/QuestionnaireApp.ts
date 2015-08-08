module QuestionnaireApp {

    export interface IControllerScope extends ng.IScope
    {
        data: QuestionnaireModel;

        addPreviousName(): void;
        removePreviousName(number): void;
    }

    enum BasicColor {
        Red,
        Blue,
        Green,
        Yellow
    }

    enum OtherGreens {
        LightGreen,
        DarkGreen
    }

    export class QuestionnaireModel {
        name: string;
        answerMoreQuestions: boolean;
        seeMoreQuestions : boolean;
        velocity: number;
        color: BasicColor;
        typeOfGreen: OtherGreens;
        ultimateQuestion: string;
        previousNames: PreviousName[];
    }

    export class PreviousName {
        firstName: string;
        previousName: string;
    }

    export class QuestionnaireController {
        private scope: IControllerScope;
        constructor($scope: IControllerScope) {
            this.scope = $scope;

            var jsonText = angular.element(document.querySelector('#data')).val();
            if (jsonText != undefined && jsonText !== 'undefined') {
                this.scope.data = JSON.parse(jsonText);
            }

            if (this.scope.data == null) {
                this.scope.data = new QuestionnaireModel();
            }

            this.scope.$watch("data.answerMoreQuestions", () => {
                if ($scope.data != null && !$scope.data.answerMoreQuestions) {
                    $scope.data.seeMoreQuestions = false;
                    $scope.data.velocity = null;
                }
            });

            this.scope.addPreviousName = () => {
                this.scope.data.previousNames.push(new PreviousName());
            };

            this.scope.removePreviousName = (index: number) => {
                this.scope.data.previousNames.splice(index, 1);
            };
        }
    }

    angular.module('QuestionnaireApp', ['ngAnimate'])
        .controller("QuestionnaireController", QuestionnaireController);
}