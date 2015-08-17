module QuestionnaireListApp {
    "use strict";
    export interface IControllerScope extends ng.IScope
    {
        data: QuestionnaireSummaryListModel;

        removeItem(item: QuestionnaireSummaryModel);
    }

    export class QuestionnaireSummaryListModel {
        items: QuestionnaireSummaryModel[];
    }

    export class QuestionnaireSummaryModel {
        id: number;
        dateCompleted: Date;
    }

    export class PreviousName {
        firstName: string;
        previousName: string;
    }

    export class QuestionnaireListController {

        constructor(private scope: IControllerScope, private http: ng.IHttpService) {
            this.http({
                url: '/api/questionnaires/list',
                method: 'GET',
                params: {
                    page: 1,
                    pageSize: 10
                }
            }).success((httpData) => {
                scope.data = <QuestionnaireSummaryListModel>httpData;
                });

            this.scope.removeItem = (item: QuestionnaireSummaryModel) => {
                this.http({
                    url: '/api/questionnaires/' + item.id,
                    method: 'DELETE'
                }).success(() => {
                    var index = scope.data.items.indexOf(item);
                    scope.data.items.splice(index, 1);
                });
            };
        }
    }

    angular.module('QuestionnaireListApp', ['ngAnimate'])
        .controller("QuestionnaireListController", ['$scope', '$http', QuestionnaireListController]);
}