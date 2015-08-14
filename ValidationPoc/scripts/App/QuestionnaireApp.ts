module QuestionnaireApp {
    "use strict";
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

        constructor() {
            this.previousNames = new Array<PreviousName>();
        }
    }

    export class PreviousName {
        firstName: string;
        previousName: string;
    }

    export class QuestionnaireController {

        private scope: IControllerScope;
        constructor(private $scope: IControllerScope) {
            this.scope = $scope;

            this.scope.data = this.getQuestionnaireModel();

            this.scope.$watch(() => $scope.data.answerMoreQuestions, () => {
                this.resetSeeMoreQuestions();
            });

            this.scope.addPreviousName = () => {
                this.scope.data.previousNames.push(new PreviousName());
            };

            this.scope.removePreviousName = (index: number) => {
                this.scope.data.previousNames.splice(index, 1);
            };
        }

        private getQuestionnaireModel(): QuestionnaireModel {
            var jsonText = angular.element(document.querySelector('#data')).val();

            var model : QuestionnaireModel = null;

            if (jsonText != undefined && jsonText !== 'undefined') {
                model = JSON.parse(jsonText);
            }

            if (model == null) {
                return new QuestionnaireModel();
            }

            return model;
        }

        private resetSeeMoreQuestions() {
            if (this.scope.data != null && !this.scope.data.answerMoreQuestions) {
                this.scope.data.seeMoreQuestions = false;
                this.scope.data.velocity = null;
            }
        }
    }

    angular.module('QuestionnaireApp', ['ngAnimate'])
        .controller("QuestionnaireController", QuestionnaireController);
}